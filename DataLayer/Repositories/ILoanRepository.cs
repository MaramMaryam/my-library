using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface ILoanRepository : IDisposable
    {
        IEnumerable<Loan> GetAll();
        User GetById(int loanId);
        bool InserLoan(Loan loan);
        bool UpdateLoan(Loan loan);
        bool DeleteLoan(Loan loan);
        bool DeleteLoan(int loanId);
        void save();
        //IEnumerable<Page> TopBooks(int take = 4);
        //IEnumerable<Page> PagesInSlider();
        //IEnumerable<Page> LastBooks(int take = 3);
        //IEnumerable<Page> ShowPageByGroupId(int groupId);
        IEnumerable<Loan> SearchLoan(string search);
        IEnumerable<LoanBookViewModel> GetUserLoanForView();
    }
}
