using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepositorry : IPageRepository
    {
        MyCmsContext db = new MyCmsContext();
        public IEnumerable<Page> GetAllPage()
        {
            return db.Pages;
        }
        public Page GePageById(int pageId)
        {
            return db.Pages.Find(pageId);
        }
        public bool InsertPage(Page page)
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
            try
            {
                db.Entry(page).State = EntityState.Modified;
                return true;
            }
            catch (Exception) { return false; }
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
            try
            {
                var page = GePageById(pageId);
                DeletePage(page);
                return true;
            }
            catch (Exception) { return false; }
        }

        public void save()
        {
            db.SaveChanges();
        }
    }
}

