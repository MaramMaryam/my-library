using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_library.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult ShowGroups()
        {
            return PartialView();
        }
    }
}