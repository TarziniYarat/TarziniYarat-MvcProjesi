using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;

namespace TarziniYarat.UI.MVC.Areas.Admin.Controllers
{
    public class AdminProcessController : Controller
    {
        IProductService _productService;
        public AdminProcessController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult ProductList()
        {
            return View();
        }


        // TODO: Body enumı alınıp ViewBag e aktarıldı.
        private void GetBodyFromEnum()
        {
            string[] bodyEnums = Enum.GetNames(typeof(Size));
            List<SelectListItem> body = new List<SelectListItem>();
            foreach (string item in bodyEnums)
            {
                body.Add(new SelectListItem { Text = item, Value = item });
            }
            ViewBag.Bodies = body;
        }

        // TODO: Color enumı alınıp ViewBag e aktarıldı.
        private void GetColorFromEnum()
        {
            string[] colorEnums = Enum.GetNames(typeof(Color));
            List<SelectListItem> color = new List<SelectListItem>();
            foreach (string item in colorEnums)
            {
                color.Add(new SelectListItem { Text = item, Value = item });
            }
            ViewBag.Color = color;
        }
        public ActionResult AddProduct()
        {
            GetBodyFromEnum();
            GetColorFromEnum();
            return View();
        }

        public ActionResult AddProduct(Product p)
        {
            GetBodyFromEnum();
            GetColorFromEnum();

            if (p.Description!=null && p.ProductTitle!=null) //buraya bak
            {
                _productService.Add(p);
            }
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