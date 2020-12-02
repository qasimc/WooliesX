using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WooliesX.Domain.Models;

namespace WooliesX.Request_Models
{
    public class TrolleyRequest
    {
        public List<Product> products { get; set; }
        public List<SpecialsGroup> specials { get; set; }
        public List<Quantity> quantities { get; set; }
    }
}
