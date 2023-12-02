using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_library.Controllers
{
    public class BooksController : Controller
    {
        MyCmsContext db = new MyCmsContext();
        private IPageGroupRepository pageGroupRepository;
        private IPageRepository pageRepository;
        public BooksController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
        }
        // GET: Books
        public ActionResult ShowGroupsInMenu()
        {
            return PartialView(pageGroupRepository.GetGroupsForView());
        }
        public ActionResult TopBooks()
        {
            return PartialView(pageRepository.TopBooks());
        }
        public ActionResult LatesBooks()
        {
            return PartialView(pageRepository.LastBooks());
        }
        [Route("Books/ArchiveBooks")]
        public ActionResult ArchiveBooks()
        {
            return View(pageRepository.GetAll());
        }
    }
}