using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IPageCommentRepository
    {
        IEnumerable<PageComment> GetAllPageComment();
        Page GePageCommentById(int pageCommentId);
        bool InsertPageComment(PageComment pageComment);
        bool UpdatePageComment(PageComment pageComment);
        bool DeletePageComment(PageComment pageComment);
        bool DeletePageComment(int pageCommentId);
        void save();

    }
}
