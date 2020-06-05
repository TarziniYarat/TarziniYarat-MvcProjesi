using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TarziniYarat.UI.MVC.Areas.Admin.Controllers
{
    public class MembersOrderController : Controller
    {
        // GET: Admin/MembersOrder
        public ActionResult StokTraking()
        {
            return View();
        }

        public ActionResult ShipperProduct()
        {
            return View();
        }
    }
}