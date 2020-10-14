using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            return Json(new { data = _db.Book.ToList()});
        }
    }
}
