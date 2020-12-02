using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Domain.Models;

namespace WooliesX.Service.Interfaces
{
    public interface IExercise2Service
    {
        ResultValue<List<Product>> GetSortedProducts(string resource, string sortOption, string token);
    }
}
