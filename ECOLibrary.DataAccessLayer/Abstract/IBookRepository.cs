using ECOLibrary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DataAccessLayer.Abstract
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> GetAllBooksWithCopies();
        bool IsBookExists(string name, string author);
        Task AddOrUpdateBookWithCopyAsync(string name, string author, string barcode);


    }
}
