using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using midterm.Models;

using System.Net;
using System.Net.Mail;


namespace midterm.Controllers
{
    public class ProductController : Controller
    {
        MidtermDbContext _context;
        public ProductController(MidtermDbContext context)
        {
            _context = context;
        }

        public IActionResult SendEmail(){
            using (var message = new MailMessage())
                {
                    message.To.Add(new MailAddress("mailTo@gmail.com", "To name"));
                    message.From = new MailAddress("matilFrom@gmail.com", "From name");
                    
                    message.Subject = "Subject";
                    message.Body = "I have sent you this email to test something";
                    message.IsBodyHtml = true;

                    using (var client = new SmtpClient("smtp.gmail.com"))
                    {
                        client.Port = 587;
                        client.Credentials = new NetworkCredential("youremail@gmail.com", "yourpassword");
                        client.EnableSsl = true;
                        client.Send(message);
                    }
                }
            return View();
        }


      
        public IActionResult Index()
        {
            var result = (from p in _context.Products
                          join s in _context.Suppliers on p.supplier_id equals s.supplier_id
                          select new ProductView
                          {
                              product_id = p.product_id,
                              product_name = p.product_name,
                              product_price = p.product_price,
                              supplier_name = s.supplier_name
                          }

                        );
            return View(result);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var product = await _context.Products.FindAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FirstOrDefaultAsync(x => x.product_id == id);
            return View(product);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            _context.Products.Add(product);
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
