using Microsoft.EntityFrameworkCore;
using midterm.Models;

public class MidtermDbContext: DbContext
{
   public MidtermDbContext(DbContextOptions<MidtermDbContext> option):base(option){

  }
   public DbSet<Product> Products { get; set; } //this is use to create an reference with table = "Products"
   public DbSet<Supplier> Suppliers { get; set; }

}