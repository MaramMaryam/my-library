using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetCommentByBooksId(int id);
        bool AddComment(PageComment comment);
        void save();
    }
}
