using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.UI.MVC.Filtres;

namespace TarziniYarat.UI.MVC.Areas.Admin.Controllers
{
    [CustomAuthorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddMember()
        {
            return View();
        }
        public ActionResult BrowseComment()
        {
            return View();
        }
    }
}