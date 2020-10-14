using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore31Tc.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetCore31Tc.Pages.BookList
{
    public class EditModel : PageModel
    {
        private AppDbContext _db;

        public EditModel(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGetAsync(int id)
        {
            Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var bookFromDb = await _db.Book.FindAsync(Book.Id);
                bookFromDb.Name = Book.Name;
                bookFromDb.Author = Book.Author;
                bookFromDb.Isbn = Book.Isbn;
                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            
            return RedirectToPage();
        }
    }
}
