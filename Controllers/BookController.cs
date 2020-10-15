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
            return await Task.Run(() => Json(new { data = _db.Book.ToListAsync() }));
        }

        //public IActionResult GetAllAsync()
        //{
        //    return Json(new { data = _db.Book.ToList() });
        //}


    }
}
