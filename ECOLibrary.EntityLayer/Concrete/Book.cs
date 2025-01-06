﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.EntityLayer.Concrete
{
    public class Book
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public ICollection<BookCopy> Copies { get; set; }
    }
}
