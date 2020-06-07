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
        IShipperService _shipperService;
        public AdminProcessController(IProductService productService, ICategoryService categoryService, IBrandService brandService, IPersonService personService, IShipperService shipperService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
            _personService = personService;
            _shipperService = shipperService;
        }


        //while creating a new product,we need to add product's brand which was created before.
        public ActionResult ProductList()
        {
            return View();
        }

        public JsonResult DeleteProduct()
        {
            return Json(JsonRequestBehavior.AllowGet);
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

            if (p.Description != null && p.ProductTitle != null) //buraya bak
            {
                _productService.Add(p);
            }
            return View();
        }

        public JsonResult DeletePerson()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

        public ActionResult PersonList()
        {
            List<Person> personList = _personService.GetAll();

            return View(personList);
        }

        public JsonResult AddPerson()
        {
            return Json(JsonRequestBehavior.AllowGet);
        }

        public JsonResult ActivatePerson(int personID)
        {
            Person person = _personService.GetByID(personID);
            if (person.IsActive==true)
            {
                person.IsActive = false;
                _personService.Update(person);
            }
            else
            {
                person.IsActive = true;
                _personService.Update(person);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);

        }

        public ActionResult BrandList()
        {
            return View(_brandService.GetAll());
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

        [HttpPost]
        public JsonResult UpdateBrand(Brand brd)
        {
            try
            {
                Brand brand = _brandService.GetByID(brd.BrandID);
                brand.CompanyName = brd.CompanyName;
                _brandService.Update(brand);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetBrand(int id)
        {
            Brand brand = _brandService.GetByID(id);

            return Json(brand, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult DeleteBrand(int id)
        {
            try
            {
                _brandService.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        private void GetAllBrands()
        {
            List<SelectListItem> brands = new List<SelectListItem>();
            foreach (Brand item in _brandService.GetAll())
            {
                brands.Add(new SelectListItem { Text = item.CompanyName, Value = item.BrandID.ToString() });
            }
            ViewBag.Brands = brands;
        }

        public ActionResult ActiveBrand(int id)
        {
            Brand brand = _brandService.GetByID(id);
            if (brand.IsActive == true)
            {
                brand.IsActive = false;
            }
            else
            {
                brand.IsActive = true;
            }
            _brandService.Update(brand);

            return Json("ok", JsonRequestBehavior.AllowGet);

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

        [HttpPost]
        public JsonResult GetCategory(int id)
        {
            Category category = _categoryService.GetByID(id);

            return Json(category, JsonRequestBehavior.AllowGet);
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

        //public ActionResult UpdateCategory(int catID)
        //{
        //    Category category = _categoryService.GetByID(catID);
        //    return View(category);
        //}

        [HttpPost]
        public JsonResult UpdateCategory(Category model)
        {
            try
            {
                Category category = _categoryService.GetByID(model.CategoryID);
                category.CategoryName = model.CategoryName;
                category.Description = model.Description;
                _categoryService.Update(category);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public ActionResult UpdateCategory(Category _category)
        //{
        //    try
        //    {
        //        Category category = _categoryService.GetByID(_category.CategoryID);
        //        category.Description = _category.Description;
        //        category.CategoryName = _category.CategoryName;
        //        _categoryService.Update(category);
        //        return RedirectToAction("CategoryList");

        //    }
        //    catch (Exception ex)
        //    {

        //        throw new Exception("Güncelleme başarısız oldu.");
        //    }
        //}

        public JsonResult DeleteCategory(int id)
        {
            try
            {
                _categoryService.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddShipper()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddShipper(Shipper model)
        {
            if (ModelState.IsValid)
            {
                Shipper shipper = new Shipper();
                shipper.CompanyName = model.CompanyName;
                shipper.Phone = model.Phone;
                try
                {
                    _shipperService.Add(shipper);
                    return RedirectToAction("shipperList");
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

        public ActionResult ShipperList()
        {
            return View(_shipperService.GetAll());
        }

        [HttpPost]
        public JsonResult UpdateShipper(Shipper model)
        {
            try
            {
                Shipper shipper = _shipperService.GetByID(model.ShipperID);
                shipper.CompanyName = model.CompanyName;
                shipper.Phone = model.Phone;
                _shipperService.Update(shipper);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult GetShipper(int id)
        {
            Shipper shipper = _shipperService.GetByID(id);

            return Json(shipper, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActiveShipper(int id)
        {
            Shipper shipper = _shipperService.GetByID(id);
            if (shipper.IsActive == true)
            {
                shipper.IsActive = false;
            }
            else
            {
                shipper.IsActive = true;
            }
            _shipperService.Update(shipper);

            return Json("ok", JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeleteShipper(int id)
        {
            try
            {
                _shipperService.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Json("ok", JsonRequestBehavior.AllowGet);
        }














    }
}