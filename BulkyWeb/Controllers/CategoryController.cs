using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationContext _db;
        public CategoryController(ApplicationContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
      
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name","The DisplayOrder can not exactly match the name");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category categoryFrmDb = _db.Categories.Find(id);
            if (categoryFrmDb == null)
            {
                return NotFound();
            }
            return View(categoryFrmDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category categoryFrmDb = _db.Categories.Find(id);
            if (categoryFrmDb == null)
            {
                return NotFound();
            }
            return View(categoryFrmDb);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult EditPost(int? id)
        {

            Category? categoryFrmDb = _db.Categories.Find(id);
            if (categoryFrmDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryFrmDb);
            _db.SaveChanges();
            TempData["success"] = "Category Created Successfully.";
            return RedirectToAction("Index");
        }
    }
}
