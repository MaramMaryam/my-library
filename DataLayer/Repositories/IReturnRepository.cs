using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IReturnRepository : IDisposable
    {
        bool ReturnBook(Return Return);
        IEnumerable<Return> GetReturns(int userId);
        //IEnumerable<Return> GetAll();
        //User GetById(int ReturnId);
        //bool InserLoan(Loan loan);
        //bool UpdateLoan(Loan loan);
        //bool DeleteLoan(Loan loan);
        //bool DeleteLoan(int loanId);
        void save();
        IEnumerable<Return> SearchReturn(string search);
        IEnumerable<LoanBookViewModel> GetUserLoanForView();
    }
}
