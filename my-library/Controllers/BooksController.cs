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
        private IPageCommentRepository pageCommentRepository;
        public BooksController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepository = new PageRepository(db);
            pageCommentRepository = new PageCommentRepository(db);
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
        [Route("Group/{id}/{title}")]
        public ActionResult ShowBooksByGroupId(int id, string title)
        {
            ViewBag.name = title;
            return View(pageRepository.ShowPageByGroupId(id));
        }
        [Route("Books/{id}")]
        public ActionResult ShowBooks(int id)
        {
            var books = pageRepository.GetById(id);
            if (books == null)
            {
                return HttpNotFound();
            }
            books.Visit += 1;
            pageRepository.UpdatePage(books);
            pageRepository.save();
            return View(books);
        }

        //[Route("Books/{id}")]
        public ActionResult AddComment(int id, string name, string email, string comment)
        {
            //if (string.IsNullOrEmpty(name))
            //{
            //    throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            //}

            //if (string.IsNullOrEmpty(email))
            //{
            //    throw new ArgumentException($"'{nameof(email)}' cannot be null or empty.", nameof(email));
            //}

            //if (string.IsNullOrEmpty(comment))
            //{
            //    throw new ArgumentException($"'{nameof(comment)}' cannot be null or empty.", nameof(comment));
            //}

            PageComment addcomment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Name = name,
                Email = email,
                Comment = comment
            };
            
            pageCommentRepository.AddComment(addcomment);
            //pageCommentRepository.save();
            return PartialView("ShowComments", pageCommentRepository.GetCommentByBooksId(id));
        }
        public ActionResult ShowComments(int id)
        {
            return PartialView(pageCommentRepository.GetCommentByBooksId(id));
        }
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        pageCommentRepository.Dispose();
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}