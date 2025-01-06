using ECOLibrary.DataAccessLayer.Abstract;
using ECOLibrary.DataAccessLayer.Concrete;
using ECOLibrary.DataAccessLayer.Repository;
using ECOLibrary.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DataAccessLayer.EntityFramework
{
    public class EfLoanRepository : GenericRepository<Loan>, ILoanRepository
    {
        public EfLoanRepository(Context context) : base(context)
        {
        }
    }
}
