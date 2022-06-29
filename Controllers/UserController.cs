using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_PRODUCT_APP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_PRODUCT_APP.Controllers
{
    public class UserController : Controller
    {
        UserDAL us = new UserDAL();
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(IFormCollection form)
        {
            User u = new User();
            u.Full_Name = form["FullName"].ToString();
            u.Email_Id = form["Email"].ToString();
            u.Password = form["Password"].ToString();
            u.RoleId = 2;
            int res = us.Save(u);
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(IFormCollection form)
        {
            User c = new User();
            c.Email_Id = form["Email_Id"].ToString();
            c.Password = form["Password"].ToString();
            bool res = us.Verify(c);
            if (res == true)
            {
                return RedirectToAction("Index","Product");
            }
            else
            {
                ViewBag.Message = "Invalid Entry";
                return View();
            }
        }
        public IActionResult Invalid()
        {
            TempData["alertMessage"] = "Invalid Email-Id or Password";
            return View();
        }
        //public IActionResult changePassword()
        //{
        //    return View();
        //}
        //public IActionResult NewUser()
        //{
        //    return View();
        //}
        //public IActionResult Logout()
        //{
        //    return View();
        //}
    }
}
