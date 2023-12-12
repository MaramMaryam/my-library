using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IBookLoanRepository
    {
        //bool IssueBook(int memberId, int bookId);
        //List<Loan> GetAll();
        //bool ReturnBook(int loanId);
        //bool ReturnBook(int pageId);
        List<Loan> GetLoans();
        Loan GetLoan(int loanId);
        bool AddLoan(Loan loan);
        double CalculatePenalty(Loan loan);
        List<Loan> GetOverdueLoans();
    }
}
