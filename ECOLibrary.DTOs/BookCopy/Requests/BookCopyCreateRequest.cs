using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.BookCopy.Requests
{
    public class BookCopyCreateRequest
    {
        public string BookId { get; set; }
        public string Barcode { get; set; }
        public bool IsAvailable { get; set; }
    }
}
