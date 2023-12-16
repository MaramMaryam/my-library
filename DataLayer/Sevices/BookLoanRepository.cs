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
        public bool CreateLoan(BookLoan loan)
        {
            //BookLoan loans = new BookLoan();

            //loan.UserID = loans.UserID;
            //loan.PageID = loans.PageID;
            ////loan.GroupID = loans.GroupID;
            //loan.LoanFrom = DateTime.Now;
            //loan.LoanUntill = DateTime.Now.AddDays(7);

            try
            {
                db.BookLoan.Add(loan);
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        }

        public List<BookLoan> GetLoans(int userId)
        {
            throw new NotImplementedException();
        }
        //public void save()
        //{
        //    db.SaveChanges();
        //}
        //public void Dispose()
        //{
        //    db.Dispose();

        //}
    }
}
