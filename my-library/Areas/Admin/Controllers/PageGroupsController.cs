using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using DataLayer;

namespace my_library.Areas.Admin.Controllers
{
    public class PageGroupsController : Controller
    {
        private IPageGroupRepository pageGroupRepository;
        MyCmsContext db = new MyCmsContext();
        public PageGroupsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
        }

        // GET: Admin/PageGroups
        public ActionResult Index()
        {
            return View(pageGroupRepository.GetAllGroups());
        }

        // GET: Admin/PageGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);
                //db.PageGroups.Find(id);
                //pageGroupRepository.GetGroupById(id.Value);
                //

            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Page page = db.Pages.Find(id);
        //    if (page == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(page);
        //}
        // GET: Admin/PageGroups/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepository.GetAllGroups(), "GroupID", "GroupTitle", "ImageGrpName");
            return View();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle,ImageGrpName")] PageGroup pageGroup, HttpPostedFileBase imgGRP)
        {
            if (ModelState.IsValid)
            {
                if (imgGRP != null)
                {
                    pageGroup.ImageGrpName = Guid.NewGuid() + Path.GetExtension(imgGRP.FileName);
                    imgGRP.SaveAs(Server.MapPath("/PageImages/" + pageGroup.ImageGrpName));

                }
                pageGroupRepository.InsertGroup(pageGroup);
                pageGroupRepository.save();
                return RedirectToAction("/Index");
            }
            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", "ImageGrpName", pageGroup.GroupID);
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //PageGroup pageGroup = db.PageGroups.Find(id);
            PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle,ImageGrpName")] PageGroup pageGroup)
        {
            if (ModelState.IsValid)
            {
                pageGroupRepository.UpdateGroup(pageGroup);
                pageGroupRepository.save();
                return RedirectToAction("/Index");
            }
            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetGroupById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // POST: Admin/PageGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pageGroupRepository.DeleteGroup(id);
            pageGroupRepository.save();
            return RedirectToAction("/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
