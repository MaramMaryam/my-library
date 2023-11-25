using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PageGroupRepository : IPageGroupRepository
    {
        private MyCmsContext db;
      
        //MyCmsContext db = new MyCmsContext();
        public PageGroupRepository(MyCmsContext context)
        {
            this.db = context;
        }
        public IEnumerable<PageGroup> GetAll()
        {
            return db.PageGroups;
        }

        public PageGroup GetById(int groupId)
        {
            return db.PageGroups.Find(groupId);
        }

        public PageGroup GetByPageId(int pageId)
        {
            throw new NotImplementedException();
        }
        public bool InsertPageGroup(PageGroup pageGroup)
        {
            try
            {
                db.PageGroups.Add(pageGroup);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePageGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Modified;
                return true;
            }
            catch (Exception) { return false; }
        }
        
        public bool DeletePageGroup(PageGroup pageGroup)
        {
            try
            {
                db.Entry(pageGroup).State = EntityState.Deleted;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        //public bool DeleteGroup(int groupId)
        //{
        //    try
        //    {
        //        var group = GetGroupById(groupId);
        //        DeleteGroup(group);
        //        return true;
        //    }
        //    catch (Exception) { return false; }

        //}
        public bool DeletePageGroup(int groupId)
        {
            try
            {
                var group = GetById(groupId);
                DeletePageGroup(group);
                return true;
            }
            catch (Exception) { return false; }
        }

        public void save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
