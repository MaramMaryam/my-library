using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageRepository:IDisposable
    {
        IEnumerable<Page> GetAll();
        Page GetById(int pageId);
        bool InserPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int pageId);
        void save();

        IEnumerable<Page> TopBooks(int take = 4);
        IEnumerable<Page> PagesInSlider();
        IEnumerable<Page> LastBooks(int take = 3);
        IEnumerable<Page> ShowPageByGroupId(int groupId);
    }
}
