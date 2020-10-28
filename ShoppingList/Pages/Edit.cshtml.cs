using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShoppingList.Model;

namespace ShoppingList.Pages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Listt Listt { get; set; }
        public async Task OnGet(int id)
        {
            Listt = await _db.Listt.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ListtFromDb = await _db.Listt.FindAsync(Listt.Id);
                ListtFromDb.Item = Listt.Item;
                ListtFromDb.Quantity = Listt.Quantity;
                await _db.SaveChangesAsync();
                return RedirectToPage("List");
            }
            return RedirectToPage();
        }
    }
}