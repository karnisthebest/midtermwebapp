using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midterm.Models;

namespace midterm.Controllers
{
    public class DashBoardController : Controller
    {

        MidtermDbContext _context;
        public DashBoardController(MidtermDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
          
            var result = await _context.Products.ToListAsync();
            return View(result);
        }

  
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
