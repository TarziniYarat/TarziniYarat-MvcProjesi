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
        ICategoryService _categoryService;
        IBrandService _brandService;
        public AdminProcessController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
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
        private void GetAllCategories()
        {
            List<SelectListItem> categories = new List<SelectListItem>();
            foreach (Category item in _categoryService.GetAll())
            {
                categories.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryID.ToString() });
            }
            ViewBag.Categories = categories;
        }

        //while creating a new product,we need to add product's brand which was created before.
        private void GetAllBrands()
        {
            List<SelectListItem> brands = new List<SelectListItem>();
            foreach (Brand item in _brandService.GetAll())
            {
                brands.Add(new SelectListItem { Text = item.CompanyName, Value = item.BrandID.ToString() });
            }
            ViewBag.Brands = brands;
        }
        public ActionResult AddProduct()
        {
            GetBodyFromEnum();
            GetColorFromEnum();
            GetAllBrands();
            GetAllCategories();
            return View();
        }

        public ActionResult AddProduct(Product p)
        {
            GetBodyFromEnum();
            GetColorFromEnum();
            GetAllBrands();
            GetAllCategories();

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

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            try
            {
                _categoryService.Add(category);
                return RedirectToAction("CategoryList");
            }
            catch (Exception ex)
            {

                throw;
            }
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

        [HttpPost]
        public ActionResult AddBrand(Brand brand)
        {
            _brandService.Add(brand);
            return RedirectToAction("BrandList");
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