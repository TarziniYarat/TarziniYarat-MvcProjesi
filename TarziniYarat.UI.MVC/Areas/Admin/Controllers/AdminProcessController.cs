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
        IPersonService _personService;
        public AdminProcessController(IProductService productService, ICategoryService categoryService, IBrandService brandService, IPersonService personService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _personService = personService;
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
            List<Category> categoryList = _categoryService.GetAll();

            return View(categoryList);
        }
        public JsonResult ActivateCategory(int categoryID)
        {
            Category category = _categoryService.GetByID(categoryID);
            category.IsActive = true;
            _categoryService.Update(category);
            return Json("ok", JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category model)
        {
            if (ModelState.IsValid)
            {
                Category category = new Category();
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;
                try
                {
                    _categoryService.Add(category);
                    return RedirectToAction("CategoryList");
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
            List<Person> personList=_personService.GetAll();

            return View(personList);
        }

        public JsonResult AddPerson()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult ActivatePerson(int personID)
        {
            Person person=_personService.GetByID(personID);
            person.IsActive = true;
            _personService.Update(person);            
            return Json("ok",JsonRequestBehavior.AllowGet);
            
        }

        public JsonResult DeletePerson()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}