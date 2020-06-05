using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TarziniYarat.UI.MVC.Areas.Admin.Controllers
{
    public class AdminProcessController : Controller
    {
        // GET: Admin/AdminProcess
        public ActionResult ProductList()
        {
            return View();
        }

        private void GetBodyFromEnum()
        {
            string[] genderEnums = Enum.GetNames(typeof());
            List<SelectListItem> genders = new List<SelectListItem>();
            foreach (string item in genderEnums)
            {
                genders.Add(new SelectListItem { Text = item, Value = item });
            }
            ViewBag.Genders = genders;
        }

        public ActionResult AddProduct()
        {
            return View();
        }

        public JsonResult DeleteProduct()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
        public ActionResult CategoryList()
        {
            return View();
        }

        public ActionResult AddCategory()
        {
            return View();
        }
        public JsonResult DeleteCategory()
        {
            return Json(JsonRequestBehavior.AllowGet);

        }

        public ActionResult BrandList()
        {
            return View();
        }

        public ActionResult AddBrand()
        {
            return View();
        }

        public JsonResult DeleteBrand()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
        public ActionResult PersonList()
        {
            return View();
        }

        public JsonResult AddPerson()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeletePerson()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}