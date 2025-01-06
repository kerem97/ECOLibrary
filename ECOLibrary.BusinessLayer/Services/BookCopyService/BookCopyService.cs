using AutoMapper;
using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DataAccessLayer.EntityFramework;
using ECOLibrary.DTOs.BookCopy.Requests;
using ECOLibrary.DTOs.BookCopy.Responses;
using ECOLibrary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Services.BookCopyService
{
    public class BookCopyService : IBookCopyService
    {
        private readonly IBookCopyRepository _bookCopyRepository;
        private readonly IMapper _mapper;

        public BookCopyService(IBookCopyRepository bookCopyRepository, IMapper mapper)
        {
            _bookCopyRepository = bookCopyRepository;
            _mapper = mapper;
        }

        public async Task AddBookCopyAsync(BookCopyCreateRequest bookCopyDto)
        {
            var bookCopy = _mapper.Map<BookCopy>(bookCopyDto);
            await _bookCopyRepository.AddAsync(bookCopy);
        }

        public async Task DeleteBookCopyAsync(string id)
        {
            await _bookCopyRepository.DeleteAsync(id);
        }

        public async Task<List<BookCopyListResponse>> GetAllBookCopiesAsync()
        {
            var bookCopies = await _bookCopyRepository.GetAllAsync();
            return _mapper.Map<List<BookCopyListResponse>>(bookCopies);
        }

        public async Task<BookCopyByIdResponse> GetBookCopyByIdAsync(string id)
        {
            var bookCopy = await _bookCopyRepository.GetByIdAsync(id);
            return _mapper.Map<BookCopyByIdResponse>(bookCopy);
        }

        public async Task UpdateBookCopyAsync(BookCopyUpdateRequest bookCopyDto)
        {
            var bookCopy = _mapper.Map<BookCopy>(bookCopyDto);
            await _bookCopyRepository.UpdateAsync(bookCopy);
        }
    }
}
