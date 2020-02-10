using ECState.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECState.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterUser(Registration objReg)
        {
            if (ModelState.IsValid)
            {
                DataContext DC = new DataContext();
                var keyNew = Helper.GeneratePassword(10);
                var password = Helper.EncodePassword(objReg.Password, keyNew);
                objReg.VCode = keyNew;
                objReg.Password = password;
                RC.registrations.Add(objReg);
                int i = RC.SaveChanges();

                if (i >= 0)
                {
                    SendVerificationLinkEmail(objReg.EmaiId);
                    return RedirectToAction("Welcome");
                }
                else
                {
                    return View("Registration has been Faild");
                }
            }
            else
                return View("");

        }

    }
}