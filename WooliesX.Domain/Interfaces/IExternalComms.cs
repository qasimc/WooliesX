using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Domain.Models;

namespace WooliesX.Domain.Interfaces
{
    public interface IExternalComms
    {
        ResultValue<Exercise1Response> GetExercise1Response(string resource);
        ResultValue<List<Product>> GetExercise2Response(string resource, string token);
        ResultValue<List<ShopperHistory>> GetShopperHistory(string token);
    }
}
