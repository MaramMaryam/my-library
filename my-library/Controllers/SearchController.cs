﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace my_library.Controllers
{
    public class SearchController : Controller
    {
        private IPageRepository pageRepository;
        MyCmsContext db = new MyCmsContext();
        public SearchController()
        {
            pageRepository = new PageRepository(db);
        }
        // GET: Search
        public ActionResult Index(string id)
        {
            ViewBag.Name = id;
            return View(pageRepository.SearchPage(id));
        }
    }
}