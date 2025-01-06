using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.BookCopy.Responses
{
    public class BookCopyListResponse
    {
        public List<BookCopyByIdResponse> BookCopies { get; set; }
    }
}
