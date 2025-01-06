using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.EntityLayer.Concrete
{
    public class BookCopy
    {
        public string Id { get; set; }
        public string BookId { get; set; }
        public Book Book { get; set; }
        public string Barcode { get; set; }
        public bool IsAvailable { get; set; }
    }
}
