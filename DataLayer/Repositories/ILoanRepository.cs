using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ILoanRepository : IDisposable
    {
        bool InserLoan(Loan loan);
        IEnumerable<Loan> GetLoans(int userId);

        //IEnumerable<Loan> GetAll();
        //Loan GetById(int loanId);
        //bool UpdateLoan(Loan loan);
        //bool DeleteLoan(Loan loan);
        //bool DeleteLoan(int loanId);
        void save();
      
        IEnumerable<Loan> SearchLoan(string search);
        IEnumerable<LoanBookViewModel> GetUserLoanForView();
    }
}
