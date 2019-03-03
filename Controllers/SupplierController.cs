using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using midterm.Models;


namespace midterm.Controllers
{
    public class SupplierController : Controller
    {
        MidtermDbContext _context;
        public SupplierController(MidtermDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _context.Suppliers.ToListAsync();
            return View(result);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            return View(supplier);
        }

        [HttpPost]
         public async Task<IActionResult> Edit(Supplier supplier)
        {
            if(supplier == null){
                return NotFound();
            }

             _context.Suppliers.Update(supplier);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null){
                return NotFound();
            }
            var supplier = await _context.Suppliers.FirstOrDefaultAsync(x => x.supplier_id == id);
            return View(supplier);
        }


        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
            await _context.SaveChangesAsync();

            return RedirectToAction("index");
        }
       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
