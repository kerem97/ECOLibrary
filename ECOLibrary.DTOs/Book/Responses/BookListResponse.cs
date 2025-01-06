using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Book.Responses
{
    public class BookListResponse
    {
        public List<BookByIdResponse> Books { get; set; }
    }
}
