using BulkyRezor_temp.Data;
using BulkyRezor_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRezor_temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private ApplicationDbContext _db;
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            TempData["success"] = "Category Created successfully.";
            return RedirectToPage("Index");
        }
    }
}
