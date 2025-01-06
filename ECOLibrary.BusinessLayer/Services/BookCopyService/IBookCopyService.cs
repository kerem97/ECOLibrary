using ECOLibrary.DTOs.BookCopy.Requests;
using ECOLibrary.DTOs.BookCopy.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Services.BookCopyService
{
    public interface IBookCopyService
    {
        Task<List<BookCopyListResponse>> GetAllBookCopiesAsync();
        Task<BookCopyByIdResponse> GetBookCopyByIdAsync(string id);
        Task AddBookCopyAsync(BookCopyCreateRequest bookCopyDto);
        Task UpdateBookCopyAsync(BookCopyUpdateRequest bookCopyDto);
        Task DeleteBookCopyAsync(string id);
    }
}
