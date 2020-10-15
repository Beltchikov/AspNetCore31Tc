using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore31Tc.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private AppDbContext _db;

        public BookController(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(b => b.Id == id);
            if (bookFromDb == null)
            {
                return Json(new { success = false, message = "Errror while deletenig" });
            }

            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Book has been deleted" });
        }
    }
}
