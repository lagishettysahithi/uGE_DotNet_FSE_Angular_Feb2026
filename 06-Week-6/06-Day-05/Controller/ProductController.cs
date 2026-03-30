using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        // In-memory list
        public static List<Product> products = new List<Product>()
        {
           new Product { ProductId = 1, ProductName = "Laptop", Price = 55000, Category = "Electronics" },
           new Product { ProductId = 2, ProductName = "Mobile", Price = 20000, Category = "Gadgets" },
           new Product { ProductId = 3, ProductName = "Chair", Price = 3000, Category = "Furniture" }

    };

        // READ (Index)
        public IActionResult Index()
        {
            return View(products);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                products.Add(obj);
                return RedirectToAction("Index");
            }

            return View();
        }

        // EDIT - GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }

        // EDIT - POST
        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            var existing = products.FirstOrDefault(x => x.ProductId == obj.ProductId);

            existing.ProductName = obj.ProductName;
            existing.Price = obj.Price;
            existing.Category = obj.Category;

            return RedirectToAction("Index");
        }

        // DELETE - GET
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }

        // DELETE - POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            products.Remove(product);

            return RedirectToAction("Index");
        }
    }
}
