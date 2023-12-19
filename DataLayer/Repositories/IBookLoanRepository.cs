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
        BookLoan GetById(int loanId);
        //public IEnumerable<BookLoan>  ;
        //          public IEnumerable<PageComment> GetCommentByBooksId(int pageId)
        //{
        //    return db.PageComments.Where(c => c.PageID == pageId);
        //}
        bool CreateLoan(BookLoan loan);
        bool ReturnBook(BookLoan loan);
            //(int bookId, DateTime? loanUntill);
        List<BookLoan> GetLoansBuUserId(int userId);
        //List<BookLoan> GetLoansBuPageId(int pageId);
        int GetLoansBuPageId(int pageId);

        void save();

    }
}
