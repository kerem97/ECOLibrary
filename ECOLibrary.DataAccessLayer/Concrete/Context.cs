using ECOLibrary.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring
          (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=HUAWEI\\SQLEXPRESS;database=EcoLibrary;integrated security=true");
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<BookCopy> BookCopies { get; set; }
    }
}
