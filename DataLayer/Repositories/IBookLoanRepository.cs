using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBookLoanRepository:IDisposable
    {
        IEnumerable<BookLoan> GetAll();
        bool CreateLoan(BookLoan loan);
        List<BookLoan> GetLoans(int userId);
        void save();

    }
}
