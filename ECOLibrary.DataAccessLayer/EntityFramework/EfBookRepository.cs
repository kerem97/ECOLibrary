using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DataAccessLayer.Concrete;
using ECOLibrary.DataAccessLayer.Repository;
using ECOLibrary.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ECOLibrary.DataAccessLayer.EntityFramework
{
    public class EfBookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly Context _context;

        public EfBookRepository(Context context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooksWithCopies()
        {
            return _context.Books
                .Include(b => b.Copies)
                .ToList();
        }
        public bool IsBookExists(string name, string author)
        {
            return _context.Books.Any(b => b.Name == name && b.Author == author);
        }
        public async Task AddOrUpdateBookWithCopyAsync(string name, string author, string barcode)
        {
            var existingBook = await _context.Books
                .Include(b => b.Copies)
                .FirstOrDefaultAsync(b => b.Name == name && b.Author == author);

            if (existingBook != null)
            {
                if (existingBook.Copies.Any(c => c.Barcode == barcode))
                {
                    throw new InvalidOperationException("Bu barkod zaten mevcut.");
                }

                existingBook.Copies.Add(new BookCopy
                {
                    Id = Guid.NewGuid().ToString(),
                    Barcode = barcode,
                    BookId = existingBook.Id,
                    IsAvailable = true
                });
            }
            else
            {
                var newBook = new Book
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = name,
                    Author = author,
                    Copies = new System.Collections.Generic.List<BookCopy>
                    {
                        new BookCopy
                        {
                            Id = Guid.NewGuid().ToString(),
                            Barcode = barcode,
                            IsAvailable=true
                        }
                    }
                };

                await _context.Books.AddAsync(newBook);
            }

            await _context.SaveChangesAsync();
        }

    }
}
