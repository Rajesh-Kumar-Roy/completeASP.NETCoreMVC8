
using Bulky.DataAccess.Data;
using Bulky.DataAccess.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
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

            Category categoryFrmDb = _unitOfWork.Category.Get(u => u.Id == id);
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
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
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

            Category categoryFrmDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFrmDb == null)
            {
                return NotFound();
            }
            return View(categoryFrmDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult EditPost(int? id)
        {

            Category? categoryFrmDb = _unitOfWork.Category.Get(u => u.Id == id);
            if (categoryFrmDb == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(categoryFrmDb);
            _unitOfWork.Save();
            TempData["success"] = "Category Created Successfully.";
            return RedirectToAction("Index");
        }
    }
}
