using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace dj_shop.Models
{
    public class ProductModel
    {
        public int Id {get; set; }
        public string ProductName {get; set;}
        public string Description {get; set;}
        public decimal Price {get; set;}
        public int StockQuantity {get; set;}
        public string Category {get; set;}

    }
}