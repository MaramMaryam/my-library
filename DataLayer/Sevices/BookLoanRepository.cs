using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
        public BookLoan GetById(int loanId)
        {
            return db.BookLoan.Find(loanId);
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
        public List<BookLoan> GetLoansBuUserId(int userId)
        {
            throw new NotImplementedException();
        }

        //public BookLoan GetLoansBuPageId(int pageId)
        //{
        //    return (db.BookLoan.Where(c => c.PageID == pageId));
        //    //return db.BookLoan.Find(pageId);

        //}
        public int GetLoansBuPageId(int pageId)
        {
            return db.BookLoan.Where(c => c.PageID == pageId)
                              .Select(c => c.UserID).FirstOrDefault();
        }
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



        //public bool ReturnBook(BookLoan loan)
        //{
        //    //var book = _context.Books.Find(bookId);
        //    try
        //    {
        //        db.Entry(loan).State = EntityState.Modified;
        //        db.SaveChanges();
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

