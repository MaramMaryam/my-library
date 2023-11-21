using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageGroupRepository
    {
        IEnumerable<PageGroup> GetAll();
        PageGroup GetById(int groupId);
        PageGroup GetByPageId(int pageId);
        bool InsertPageGroup(PageGroup pageGroup);
        bool UpdatePageGroup(PageGroup pageGroup);
        bool DeletePageGroup(PageGroup pageGroup);
        bool DeletePageGroup(int pageId);

        void save();
    }
}
