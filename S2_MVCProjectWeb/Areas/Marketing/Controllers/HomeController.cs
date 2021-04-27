using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using S2_MVCProjectWeb.Areas.Marketing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace S2_MVCProjectWeb.Areas.Marketing
{
    [Area("Marketing")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductsViewModel()
        {
            var products = GetProductsJsonLocal();
            return View(products);
        }

        public IActionResult ProductsViewData()
        {
            return View();
        }

        public IActionResult ProductsViewBag()
        {
            return View();
        }

        public IEnumerable<Product> GetProductsJsonLocal()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"Areas\\Marketing\\Data\\products.json");
            
            var json = System.IO.File.ReadAllText(folderDetails);

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            
            return products;
        }

    }
}
