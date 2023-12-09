﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security;
using System.Web.Security;

namespace my_library
{
    public class AccountController : Controller
    {
        private ILoginRepository loginRepository;
        MyCmsContext db = new MyCmsContext();
        public AccountController()
        {
            loginRepository = new LoginRepository(db);
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                if (loginRepository.IsExitUser(login.UserName, login.Password))
                {
                    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                    return Redirect("/");
                }
                else 
                {
                    ModelState.AddModelError("UserName", "کاربری یافت نشد");
                }
            }

            return View(login);
        }
    }
}