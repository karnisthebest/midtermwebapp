using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace midterm.Models
{
    public class Supplier
    {
        [Key]
        public int supplier_id { get; set; }
        public string supplier_name { get; set; }
        public string supplier_address { get; set; }


    }
}