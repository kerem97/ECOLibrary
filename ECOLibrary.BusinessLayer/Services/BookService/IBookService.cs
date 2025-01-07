using ECOLibrary.DTOs.Book.Requests;
using ECOLibrary.DTOs.Book.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Services.BookService
{
    public interface IBookService
    {
        Task<List<BookListResponse>> GetAllBooksAsync();
        Task<BookByIdResponse> GetBookByIdAsync(string id);
        Task<List<BookListResponse>> GetAllBooksWithCopiesAsync();
        Task AddBookAsync(BookCreateRequest bookDto);
        Task UpdateBookAsync(BookUpdateRequest bookDto);
        Task DeleteBookAsync(string id);
    }
}
