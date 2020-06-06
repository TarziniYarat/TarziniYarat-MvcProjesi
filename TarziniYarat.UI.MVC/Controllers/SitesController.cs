using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;
using TarziniYarat.UI.MVC.Models;

namespace TarziniYarat.UI.MVC.Controllers
{
    public class SitesController : Controller
    {
        IPersonService _personService;
        IRoleService _roleService;

        public SitesController(IPersonService personService, IRoleService roleService)
        {
            _personService = personService;
            _roleService = roleService;
        }
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult Shop()
        {
            return View();
        }
        public ActionResult ProductDetail()
        {
            return View();
        }
        public ActionResult Combine()
        {
            return View();
        }
        public ActionResult CreateCombine()
        {
            return View();
        }
        public ActionResult ViewCombine()
        {
            return View();
        }
        public ActionResult AllViewCombine()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult BlogDetail()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                Person person = new Person();
                person.Name = model.Name;
                person.Surname = model.Surname;
                person.Username = model.UserName;
                person.Password = model.Password;
                person.BirthDate = model.BirthDate.ToString();
                person.Role = _roleService.GetRoleByName("Manager");

                try
                {
                    _personService.Add(person);
                    //return RedirectToAction("Login");
                    return RedirectToAction("WaitPage");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            else
            {
                ModelState.AddModelError("", "Girdiğiniz bilgileri kontrol ediniz");
            }
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult WaitPage()
        {
            return View();
        }
    }
}