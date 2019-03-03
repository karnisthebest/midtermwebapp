using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace midterm.Models
{
    public class Product
    {
        [Key]
        public int product_id { get; set; }
        public string product_name { get; set; }
        public int product_qty { get; set; }
        public double product_price { get; set; }
        public int supplier_id { get; set; }


    }
}
