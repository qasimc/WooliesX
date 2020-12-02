using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesX.Domain.Models
{
    public class ShopperHistory
    {
        public int CustomerId { get; set; }
        public List<Product> products { get; set; }
    }
}
