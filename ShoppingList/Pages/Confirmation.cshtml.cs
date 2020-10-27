using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingList.Model;

namespace ShoppingList.Pages
{
    public class ConfirmationModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ConfirmationModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Listt Listt { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Listt.Add(Listt);
            await _db.SaveChangesAsync();
            return Page();
        }
    }
}