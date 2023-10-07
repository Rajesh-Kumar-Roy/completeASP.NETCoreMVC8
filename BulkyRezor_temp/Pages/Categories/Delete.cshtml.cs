using BulkyRezor_temp.Data;
using BulkyRezor_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRezor_temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private ApplicationDbContext _db;
        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if (id != null || id != 0)
            {
                Category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost(int? id)
        {
            Category = _db.Categories.Find(id);
            if (Category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(Category);
            _db.SaveChanges();
            TempData["success"] = "Category deleted Successfully.";
            return RedirectToPage("Index");
        }
    }
}
