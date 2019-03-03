using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace midterm.Models
{
    public class SaleOrder
    {
        [Key]
        public int id { get; set; }
        public int zone { get; set; }
        public double sale_amount { get; set; }
        


    }
}
