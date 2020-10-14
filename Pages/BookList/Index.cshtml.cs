using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore31Tc.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore31Tc.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private AppDbContext _db;

        public IndexModel(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGetAsync()
        {
            Books = await _db.Book.ToListAsync();
        }
    }
}
