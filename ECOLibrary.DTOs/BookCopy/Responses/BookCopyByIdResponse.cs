using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.BookCopy.Responses
{
    public class BookCopyByIdResponse
    {
        public string Id { get; set; }
        public string BookName { get; set; }
        public string Barcode { get; set; }
        public bool IsAvailable { get; set; }
    }
}
