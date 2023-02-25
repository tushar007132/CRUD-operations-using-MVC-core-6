using BulkyBook.DataAccess.Repository;
using BulkyBook.Models;
using Microsoft.AspNetCore.Mvc;

namespace UdemyProject1.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _db;

        public ProductController(IProductRepository db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> ProductList = _db.GetAll();
            return View(ProductList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var ProductFromDb = _db.GetFirstOrDefault(u => u.Id == id);

            if (ProductFromDb == null) return NotFound();

            return View(ProductFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _db.Update(obj);
                _db.Save();
                TempData["success"] = "Product Edited successfully";
                return RedirectToAction("index");
            }
            return View(obj);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            var ProductFromDb = _db.GetFirstOrDefault(u => u.Id == id);

            if (ProductFromDb == null) return NotFound();

            return View(ProductFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeletePost(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.Save();
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("index");
        }

    }
}
