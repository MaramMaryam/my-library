using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepository
    {
        bool AddComment(PageComment comment);
        //void save();
        IEnumerable<PageComment> GetCommentByBooksId(int pageId); 
    }
}
