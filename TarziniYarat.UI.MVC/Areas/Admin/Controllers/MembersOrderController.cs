using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;
using TarziniYarat.BusinessLogic.Abstract;
using TarziniYarat.Model;
using TarziniYarat.UI.MVC.Areas.Admin.ViewModels;

namespace TarziniYarat.UI.MVC.Areas.Admin.Controllers
{
    public class MembersOrderController : Controller
    {
        IShipperService _shipperService;
        IProductService _productService;
        public MembersOrderController(IShipperService shipperService, IProductService productService)
        {
            _shipperService = shipperService;
            _productService = productService;
        }
        public ActionResult StokTraking()
        {
            return View();
        }

        public ActionResult ShipperProduct(int? id)
        {
            if (id.HasValue)
            {
                List<ShipperProductVM> shippers = new List<ShipperProductVM>();

                foreach (Product item in _productService.GetAllByShipper(id))
                {
                    shippers.Add(new ShipperProductVM()
                    {
                        CompanyName = item.Shipper.CompanyName,
                        Phone = item.Shipper.Phone,
                        ProductName = item.ProductName,

                    });
                }

                return View(shippers);

            }
            else
            {
                return RedirectToAction("ShipperList","AdminProcess");
            }
        }
    }
}