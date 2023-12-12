using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LoanRepository:ILoanRepository
    {
        private MyCmsContext db;
        public LoanRepository(MyCmsContext context)
        {
            this.db = context;
        }
        //public IEnumerable<User> GetAll()
        //{
        //    return db.Loan;
        //}

        //public User GetById(int userId)
        //{
        //    return db.User.Find(userId);
        //}

        //public bool InserPage(User user)
        //{
        //    try
        //    {
        //        db.User.Add(user);
        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}
        //public bool UpdatePage(User user)
        //{
        //    try
        //    {
        //        db.Entry(user).State = EntityState.Modified;
        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}
        //public bool DeletePage(User user)
        //{
        //    try
        //    {
        //        db.Entry(user).State = EntityState.Deleted;
        //        return true;
        //    }
        //    catch (Exception) { return false; }
        //}

        //public bool DeletePage(int userId)
        //{
        //    var user = GetById(userId);
        //    DeletePage(user);
        //    return true;
        //}

        public void save()
        {
            db.SaveChanges();
        }
        //public IEnumerable<Page> SearchPage(string search)
        //{
        //    return db.Pages.Where(p => p.Title.Contains(search) || p.ShortDescription.Contains(search) ||
        //    p.Tags.Contains(search) || p.Text.Contains(search)).Distinct();
        //}
        public void Dispose()
        {
            db.Dispose();
        }

        public bool InserLoan(Loan loan)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> GetLoans(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Loan> SearchLoan(string search)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoanBookViewModel> GetUserLoanForView()
        {
            throw new NotImplementedException();
        }
    }
}
