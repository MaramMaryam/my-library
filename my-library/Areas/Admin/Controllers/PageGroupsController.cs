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
            return View(pageGroupRepository.GetAll());
        }

        // GET: Admin/PageGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetById(id.Value);
            if (pageGroup == null)
            {
                return HttpNotFound();
            }
            return PartialView(pageGroup);
        }

        // GET: Admin/PageGroups/Create
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Admin/PageGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupID,GroupTitle,GroupImgName")] PageGroup pageGroup, HttpPostedFileBase imgUpPageGroup)
        {
            if (ModelState.IsValid)
            {

                if (imgUpPageGroup != null)
                {
                    pageGroup.GroupImgName = Guid.NewGuid() + Path.GetExtension(imgUpPageGroup.FileName);
                    imgUpPageGroup.SaveAs(Server.MapPath("/PageGroupImages/" + pageGroup.GroupImgName));
                }

                pageGroupRepository.InsertPageGroup(pageGroup);
                pageGroupRepository.save();
                return RedirectToAction("/Index");
            }

            return View(pageGroup);
        }

        // GET: Admin/PageGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageGroup pageGroup = pageGroupRepository.GetById(id.Value);

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
        public ActionResult Edit([Bind(Include = "GroupID,GroupTitle,GroupImgName")] PageGroup pageGroup, HttpPostedFileBase imgUpPageGroup)
        {
            if (ModelState.IsValid)
            {

                if (imgUpPageGroup != null)
                {
                    if (pageGroup.GroupImgName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageGroupImages/" + pageGroup.GroupImgName));
                    }
                    pageGroup.GroupImgName = Guid.NewGuid() + Path.GetExtension(imgUpPageGroup.FileName);
                    imgUpPageGroup.SaveAs(Server.MapPath("/PageGroupImages/" + pageGroup.GroupImgName));
                }

                pageGroupRepository.UpdatePageGroup(pageGroup);
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
            PageGroup pageGroup = pageGroupRepository.GetById(id.Value);
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
            pageGroupRepository.DeletePageGroup(id);
            pageGroupRepository.save();
            //PageGroup pageGroup = db.PageGroups.Find(id);
            //db.PageGroups.Remove(pageGroup);
            //db.SaveChanges();
            return RedirectToAction("/Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepository.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
