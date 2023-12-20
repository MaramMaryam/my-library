using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataLayer;

namespace my_library.Areas.Admin.Controllers
{
    public class BookLoansController : Controller
    {
        private MyCmsContext db = new MyCmsContext();

        // GET: Admin/BookLoans
        public ActionResult Index()
        {
            var bookLoan = db.BookLoan.Include(b => b.Pages).Include(b => b.User);
            return View(bookLoan.ToList());
        }

        // GET: Admin/BookLoans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLoan bookLoan = db.BookLoan.Find(id);
            if (bookLoan == null)
            {
                return HttpNotFound();
            }
            return View(bookLoan);
        }

        // GET: Admin/BookLoans/Create
        public ActionResult Create()
        {
            ViewBag.PageID = new SelectList(db.Pages, "PageID", "Title");
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FullName");
            return View();
        }

        // POST: Admin/BookLoans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookLoanID,PageID,UserID,LoanFrom,LoanUntill,ReturnedOn")] BookLoan bookLoan)
        {
            if (ModelState.IsValid)
            {
                db.BookLoan.Add(bookLoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PageID = new SelectList(db.Pages, "PageID", "Title", bookLoan.PageID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FullName", bookLoan.UserID);
            return View(bookLoan);
        }

        // GET: Admin/BookLoans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLoan bookLoan = db.BookLoan.Find(id);
            if (bookLoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageID = new SelectList(db.Pages, "PageID", "Title", bookLoan.PageID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FullName", bookLoan.UserID);
            return View(bookLoan);
        }

        // POST: Admin/BookLoans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookLoanID,PageID,UserID,LoanFrom,LoanUntill,ReturnedOn")] BookLoan bookLoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookLoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PageID = new SelectList(db.Pages, "PageID", "Title", bookLoan.PageID);
            ViewBag.UserID = new SelectList(db.Users, "UserID", "FullName", bookLoan.UserID);
            return View(bookLoan);
        }

        // GET: Admin/BookLoans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookLoan bookLoan = db.BookLoan.Find(id);
            if (bookLoan == null)
            {
                return HttpNotFound();
            }
            return View(bookLoan);
        }

        // POST: Admin/BookLoans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookLoan bookLoan = db.BookLoan.Find(id);
            db.BookLoan.Remove(bookLoan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
