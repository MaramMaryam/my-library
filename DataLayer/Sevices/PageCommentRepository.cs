using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageCommentRepository : IPageCommentRepository
    {
        private MyCmsContext db;
        public PageCommentRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public bool InsertComment(PageComment comment)
        {
            try
            {
                db.PageComments.Add(comment);
                //db.SaveChanges();
                return true;
            }
            catch (Exception) { return false; }
        } 
        public void save()
        {
            db.SaveChanges();
        }
        public IEnumerable<PageComment> GetCommentByBooksId(int pageId)
        {
            return db.PageComments.Where(c => c.PageID == pageId);
        }

       
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
