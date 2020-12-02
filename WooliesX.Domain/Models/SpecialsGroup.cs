using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesX.Domain.Models
{
    public class SpecialsGroup
    {
        public List<Quantity> quantities { get; set; }
        public double total { get; set; }
    }
}
