﻿using AutoMapper;
using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DTOs.Book.Requests;
using ECOLibrary.DTOs.Book.Responses;
using ECOLibrary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }
        public async Task<List<BookListResponse>> GetAllBooksWithCopiesAsync()
        {
            var books = _bookRepository.GetAllBooksWithCopies();
            var response = books.Select(book => new BookListResponse
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Barcode = string.Join(", ", book.Copies.Select(c => c.Barcode)),
                StockCount = book.Copies.Count(c => c.IsAvailable),
                IsAvailable = book.Copies.Any(c => c.IsAvailable)
            }).ToList();

            return response;
        }
        public async Task AddBookAsync(BookCreateRequest bookRequest)
        {
            await _bookRepository.AddOrUpdateBookWithCopyAsync(bookRequest.Name, bookRequest.Author, bookRequest.Barcode);
        }

        public async Task DeleteBookAsync(string id)
        {
            await _bookRepository.DeleteAsync(id);
        }

        public async Task<List<BookListResponse>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<List<BookListResponse>>(books);
        }

        public async Task<BookByIdResponse> GetBookByIdAsync(string id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<BookByIdResponse>(book);
        }

        public async Task UpdateBookAsync(BookUpdateRequest bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.UpdateAsync(book);
        }

      
    }
}
