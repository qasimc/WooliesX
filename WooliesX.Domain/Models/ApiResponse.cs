using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesX.Domain.Models
{
    public class ApiResponse
    {
        public bool passed { get; set; }
        public string url { get; set; }
        public object message { get; set; }
    }
}
