using BulkyRezor_temp.Data;
using BulkyRezor_temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRezor_temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;
        public List<Category> Categorylist { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categorylist = _db.Categories.ToList();
        }
    }
}
