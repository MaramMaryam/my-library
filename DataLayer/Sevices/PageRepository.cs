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
            var page = GetById(pageId);
            DeletePage(page);
            return true;
        }

        public void save()
        {
            db.SaveChanges();
        }

        public IEnumerable<Page> TopBooks(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> PagesInSlider()
        {
            return db.Pages.Where(p => p.ShowInSlider == true);
        }

        public IEnumerable<Page> LastBooks(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroupId(int groupId)
        {
            return db.Pages.Where(p => p.GroupID == groupId);
        }
        public IEnumerable<Page> SearchPage(string search)
        {
            return db.Pages.Where(p=>p.Title.Contains(search) || p.ShortDescription.Contains(search) || 
            p.Tags.Contains(search) || p.Text.Contains(search)).Distinct();
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
