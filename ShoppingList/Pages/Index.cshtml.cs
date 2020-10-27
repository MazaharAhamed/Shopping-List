using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShoppingList.Model;

namespace ShoppingList.Pages
{
    public class IndexModel : PageModel
    {
        private ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        public Listt Listt { get; set; }
        public void OnGet()
        {

        }

        public async Task <IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _db.Listt.Add(Listt);
            await _db.SaveChangesAsync();
            return RedirectToPage("/List");

        }

    }
}
