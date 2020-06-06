using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;
using TarziniYarat.UI.MVC.Models;
using TarziniYarat.UI.MVC.Views;

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
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            List<Person> persons = _personService.GetAll();
            foreach (var item in persons)
            {
                if (login.UserName == item.Username && login.Password == item.Password)
                {
                    if (item.RoleID == 1)
                    {
                        return RedirectToAction("Index", "Admin", new { area = "Admin", id = item.PersonID });
                    }
                    else
                    {
                        throw new Exception("admin değildir");
                    }
                }
                else
                {
                    throw new Exception("Kullanıcı adı veya şifre hatalı");
                }

            }
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
                person.TCKN = model.TCKN;
                person.RoleID = 4;
                //person.PersonID = 1;

                try
                {
                    _personService.Add(person);
                    
                    
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
                return RedirectToAction("WaitPage");
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