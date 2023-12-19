using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        //public bool ReturnBook(int bookId, DateTime? loanUntill)
        //{
        //    //public bool UpdatePage(Page page)
        //    //{
        //        try
        //        {
        //            db.Entry(page).State = EntityState.Modified;
        //            return true;
        //        }
        //        catch (Exception) { return false; }
        //    //}
        //    try
        //    {
        //        db.BookLoan.Add(loan);
        //        db.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}

        public bool ReturnBook(BookLoan loan)
        {
            try
            {
                db.Entry(loan).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
            //}
        }

        public void save()
        {
            db.SaveChanges();
        }

        //public bool ReturnBook(int userId, int pageId)
        //{
        //    try
        //    {
        //        db.Entry(loan).State = EntityState.Modified;
        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}
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

