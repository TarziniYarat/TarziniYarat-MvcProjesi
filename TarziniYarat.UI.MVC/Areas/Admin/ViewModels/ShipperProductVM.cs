using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TarziniYarat.UI.MVC.Areas.Admin.ViewModels
{
    public class ShipperProductVM
    {
        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string ProductName { get; set; }

    }
}