using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBookLoanRepository
    {
        IEnumerable<BookLoan> GetAll();
        bool CreateLoan(BookLoan loan);
        bool ReturnBook(BookLoan loan);
            //(int bookId, DateTime? loanUntill);
        List<BookLoan> GetLoans(int userId);
        void save();

    }
}
