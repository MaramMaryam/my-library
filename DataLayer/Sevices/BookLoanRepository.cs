using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BookLoanRepository : IBookLoanRepository
    {
        private MyCmsContext db;
        public BookLoanRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<BookLoan> GetAll()
        {
            return db.BookLoan;
        }
        //public bool InserPage(Page page)
        //{
        //    try
        //    {
        //        db.Pages.Add(page);
        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}
        public bool CreateLoan(BookLoan loan)
        {
            var loans = new BookLoan();
            loan.UserID = loans.UserID;
            loan.PageID = loans.PageID;
            loan.LoanFrom = DateTime.Now;
            loan.LoanUntill = DateTime.Now.AddDays(7);
            try
            {
                db.BookLoan.Add(loans);
                return true;
            }
            catch (Exception) { return false; }
        }

        public List<BookLoan> GetLoans(int userId)
        {
            throw new NotImplementedException();
        }
        public void save()
        {
            db.SaveChanges();
        }
        public void Dispose()
        {
            db.Dispose();

        }
    }
}
