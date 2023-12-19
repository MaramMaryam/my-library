using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Xml.Linq;
using DataLayer;

namespace my_library.Areas.Admin.Controllers
{
    [Authorize]

    public class PagesController : Controller
    {
        private IPageRepository pageRepository;
        private IPageGroupRepository pageGroupRepository;
        private IBookLoanRepository bookLoanRepository;
        private IUserRepository userRepository;

        private MyCmsContext db = new MyCmsContext();
        public PagesController()
        {
            pageRepository = new PageRepository(db);
            pageGroupRepository = new PageGroupRepository(db);
            bookLoanRepository = new BookLoanRepository(db);
            userRepository = new UserRepository(db);

        }
        // GET: Admin/Pages
        public ActionResult Index()
        {
            //var pages = db.Pages.Include(p => p.PageGroup);
            return View(pageRepository.GetAll());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = db.Pages.Find(id);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAll(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,Author,ShortDescription,Text,Tags,Visit,ImageName," +
            "ShowInSlider,CreateDate,AvailableCount,BorrowCount")] Page page, HttpPostedFileBase imgUpPage)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;
                page.AvailableCount = 1;
                page.BorrowCount = 0;

                if (imgUpPage != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUpPage.FileName);
                    imgUpPage.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }
                pageRepository.InserPage(page);
                pageRepository.save();
                //db.Pages.Add(page);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAll(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,Author,ShortDescription,Text,Tags," +
            "Visit,ImageName,ShowInSlider,CreateDate,AvailableCount,BorrowCount")] Page page, HttpPostedFileBase imgUpPage)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(page).State = EntityState.Modified;
                //db.SaveChanges();

                if (imgUpPage != null)
                {
                    if (page.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
                    }
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUpPage.FileName);
                    imgUpPage.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }

                pageRepository.UpdatePage(page);
                pageRepository.save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepository.GetById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Page page = db.Pages.Find(id);
            //db.Pages.Remove(page);
            //db.SaveChanges();
            var page = pageRepository.GetById(id);
            if (page.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
            }
            pageRepository.DeletePage(id);
            pageRepository.save();
            return RedirectToAction("Index");
        }

        public ActionResult CreateLoan(int id)
        {
            Page page = pageRepository.GetById(id);
            //ViewBag.GroupID = new SelectList(pageGroupRepository.GetAll(), "GroupID", "GroupTitle");
            ViewBag.PageID = page.PageID;
            //new SelectList(pageRepository.GetAll(), "PageID", "Title");
            //page.PageID;
            //new SelectList(pageRepository.GetAll(), "PageID", "Title");
            ViewBag.UserID = new SelectList(userRepository.GetAll(), "UserID", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateLoan(BookLoan bookLoan, int userId, int pageId)
        //[Bind(Include = "BookLoanID,PageID,UserID,LoanFrom,LoanUntill"
        //)] BookLoan bookLoan)
        {
            Page page = pageRepository.GetById(pageId);

            if (ModelState.IsValid)
            {
                if (page.AvailableCount == 0)
                {
                    return HttpNotFound();
                }
                BookLoan addLoan = new BookLoan()
                {
                    UserID = userId,
                    PageID = page.PageID,
                    //loan.GroupID = loans.GroupID;
                    LoanFrom = DateTime.Now,
                    LoanUntill = DateTime.Now.AddDays(7),
                };
                ViewBag.PageID = addLoan.PageID;
                ViewBag.UserID = new SelectList(db.Users, "UserID", "FullName", bookLoan.UserID);
                bookLoanRepository.CreateLoan(addLoan);
                page.AvailableCount -= 1;
                page.BorrowCount += 1;
                pageRepository.save();
                return RedirectToAction("/Index");
            }
            //new SelectList(db.Users, "UserID", "FullName", bookLoan.UserID);
            //bookLoan.PageID;
            //new SelectList(db.Pages, "PageID", "Title", bookLoan.PageID);
            //return View(bookLoan);
            return RedirectToAction("/Index");
        }

        public ActionResult ReturnBook(BookLoan returnbook, int id)
        {
            Page page = pageRepository.GetById(id);
            BookLoan bookloan = bookLoanRepository.GetById(page.PageID);
            var b = bookLoanRepository.GetLoansBuPageId(page.PageID);


            //if (page.PageID == bookloan.PageID)
            //{
            //    ViewBag.UserID = bookloan.UserID;
            //    //ViewBag.BookLoanID = bookloan.BookLoanID;

            //}
            //ViewBag.GroupID = new SelectList(pageGroupRepository.GetAll(), "GroupID", "GroupTitle");
            ViewBag.PageID = page.PageID;
            ViewBag.UserID = b;
            //if (bookloan.PageID == page.PageID)
            //{
            //    ViewBag.UserID = bookloan.UserID;
            //    ViewBag.BookLoanID = bookloan.BookLoanID;

            //}
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReturnBook([Bind(Include = "BookLoanID,PageID,UserID,LoanFrom,LoanUntill"
        )] BookLoan returnbook, int pageId,  int loanId)
        {
            Page page = pageRepository.GetById(pageId);
            var bookLoans  = bookLoanRepository.GetAll();
            var b = bookLoanRepository.GetLoansBuPageId(page.PageID);   
            if (ModelState.IsValid)
            {
                if (page.AvailableCount != 0)
                {
                    return HttpNotFound();
                }
                //BookLoan returnBook = new BookLoan()
                //{
                //returnbook.UserID = returnbook.UserID;
                //returnbook.PageID = returnbook.PageID;
                ////loan.GroupID = loans.GroupID;
                //returnbook.LoanFrom = returnbook.LoanFrom;
                //returnbook.LoanUntill = returnbook.LoanUntill;
                returnbook.ReturnedOn = DateTime.Now;
                //};
                ViewBag.PageID = returnbook.PageID;
                ViewBag.UserID = b;
                //if (bookloan.PageID == page.PageID)
                //{
                //    ViewBag.UserID = bookloan.UserID;
                //    ViewBag.BookLoanID = bookloan.BookLoanID;

                //}

                //ViewBag.UserID = new SelectList(db.Users, "UserID", "FullName", bookLoan.UserID);
                bookLoanRepository.ReturnBook(returnbook);
                page.AvailableCount += 1;
                page.BorrowCount -= 1;
                pageRepository.save();
                bookLoanRepository.save();
                return RedirectToAction("/Index");
            }
            //new SelectList(db.Users, "UserID", "FullName", bookLoan.UserID);
            //bookLoan.PageID;
            //new SelectList(db.Pages, "PageID", "Title", bookLoan.PageID);
            //return View(bookLoan);
            return RedirectToAction("/Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageRepository.Dispose();
                pageGroupRepository.Dispose();
                db.Dispose();
            }
            //if (disposing)
            //{
            //    pageGroupRepository.Dispose();
            //    pageRepository.Dispose();
            //    db.Dispose();
            //}
            base.Dispose(disposing);
        }
    }
}
