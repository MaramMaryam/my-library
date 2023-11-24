using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageRepository : IPageRepository
    {
        private MyCmsContext db;
        public PageRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<Page> GetAll()
        {
            return db.Pages;
        }

        public Page GetById(int pageId)
        {
            return db.Pages.Find(pageId);
        }

        public bool InserPage(Page page)
        {
            try
            {
                db.Pages.Add(page);
                return true;
                    }
            catch (Exception) { return false; }
        }
        public bool UpdatePage(Page page)
        {
            try{
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch(Exception){ return false; }
        }
        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception) { return false; }
        }

        public bool DeletePage(int pageId)
        {
            var page = GetById(pageId);
            DeletePage(page);
            return true;
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}
