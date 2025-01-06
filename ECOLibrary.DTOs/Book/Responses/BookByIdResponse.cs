using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Book.Responses
{
    public class BookByIdResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Barcode { get; set; }
    }
}
