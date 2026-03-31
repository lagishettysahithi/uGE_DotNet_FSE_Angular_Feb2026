using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;


namespace WebApplication2.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        // GET → Show form + list
        [HttpGet("index")]
        public IActionResult Index()
        {
            var products = GetProducts();
            ViewBag.Products = products;

            return View();
        }

        //  POST → Add product
        [HttpPost("add")]
        public IActionResult Add(string name, decimal price, int quantity)
        {
            var products = GetProducts();

            // Add new product
            products.Add(new Dictionary<string, string>
            {
                { "Name", name },
                { "Price", price.ToString() },
                { "Quantity", quantity.ToString() }
            });

            SaveProducts(products);

            return RedirectToAction("Index"); // PRG pattern
        }

        //  Get from Session
        private List<Dictionary<string, string>> GetProducts()
        {
            var data = HttpContext.Session.GetString("Products");

            if (string.IsNullOrEmpty(data))
                return new List<Dictionary<string, string>>();

            return JsonSerializer.Deserialize<List<Dictionary<string, string>>>(data);
        }

        //  Save to Session
        private void SaveProducts(List<Dictionary<string, string>> products)
        {
            var data = JsonSerializer.Serialize(products);
            HttpContext.Session.SetString("Products", data);
        }
    }
}
