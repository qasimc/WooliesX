using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Domain.Models;

namespace WooliesX.Service.Interfaces
{
    public interface IExercise3Service
    {
        ResultValue<double> CalculateMinimumTrolleyTotal(List<SpecialsGroup> specials, List<Product> products, List<Quantity> trolleyQuantities);
    }
}
