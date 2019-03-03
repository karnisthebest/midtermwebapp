using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace midterm.Models
{
    public class ProductView
    {

        public int product_id { get; set; }
        public string product_name { get; set; }
        public double product_price { get; set; }
        public string supplier_name { get; set; }

    }
}