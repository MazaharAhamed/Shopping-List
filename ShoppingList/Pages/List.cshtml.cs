using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShoppingList.Model;

namespace ShoppingList.Pages
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public ListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Listt> Listt { get; set; }
        public async Task OnGet()
        {
            Listt = await _db.Listt.ToListAsync();
        }

        public IActionResult Click()
        {
            return RedirectToPage("Edit");
        }

        public async Task<IActionResult> Delete()
        {
            if (ModelState.IsValid)
            {
                _db.Remove(Listt);
                await _db.SaveChangesAsync();
                return RedirectToPage("List");
            }
            return Page();
        }
    }
}