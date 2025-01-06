using AutoMapper;
using ECOLibrary.DTOs.Book.Requests;
using ECOLibrary.DTOs.Book.Responses;
using ECOLibrary.DTOs.BookCopy.Requests;
using ECOLibrary.DTOs.BookCopy.Responses;
using ECOLibrary.DTOs.Employee.Requests;
using ECOLibrary.DTOs.Employee.Responses;
using ECOLibrary.DTOs.Loan.Requests;
using ECOLibrary.DTOs.Loan.Responses;
using ECOLibrary.DTOs.User.Requests;
using ECOLibrary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.BusinessLayer.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookByIdResponse>().ReverseMap();
            CreateMap<Book, BookListResponse>().ReverseMap();
            CreateMap<Book, BookCreateRequest>().ReverseMap();
            CreateMap<Book, BookUpdateRequest>().ReverseMap();

            CreateMap<BookCopy, BookCopyByIdResponse>().ReverseMap();
            CreateMap<BookCopy, BookCopyListResponse>().ReverseMap();
            CreateMap<BookCopy, BookCopyCreateRequest>().ReverseMap();
            CreateMap<BookCopy, BookCopyUpdateRequest>().ReverseMap();

            CreateMap<Employee, EmployeeByIdResponse>().ReverseMap();
            CreateMap<Employee, EmployeeListResponse>().ReverseMap();
            CreateMap<Employee, EmployeeCreateRequest>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateRequest>().ReverseMap();

            CreateMap<Loan, LoanByIdResponse>().ReverseMap();
            CreateMap<Loan, LoanListResponse>().ReverseMap();
            CreateMap<Loan, LoanCreateRequest>().ReverseMap();
            CreateMap<Loan, LoanUpdateRequest>().ReverseMap();

            CreateMap<User, UserCreateRequest>().ReverseMap();
            CreateMap<User, UserUpdateRequest>().ReverseMap();

        }
    }
}
