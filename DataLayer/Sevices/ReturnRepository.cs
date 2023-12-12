using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ReturnRepository : IReturnRepository
    {
        private MyCmsContext db;
        public ReturnRepository(MyCmsContext context)
        {
            this.db = context;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Return> GetReturns(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LoanBookViewModel> GetUserLoanForView()
        {
            throw new NotImplementedException();
        }

        public bool ReturnBook(Return Return)
        {
            throw new NotImplementedException();
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Return> SearchReturn(string search)
        {
            throw new NotImplementedException();
        }
    }
}
