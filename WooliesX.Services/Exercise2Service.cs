using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Domain.Interfaces;
using WooliesX.Domain.Models;
using WooliesX.Service.Interfaces;

using System.Linq;

namespace WooliesX.Services
{
    public class Exercise2Service : IExercise2Service
    {
        IExternalComms ExternalComms;
        public Exercise2Service(IExternalComms externalComms)
        {
            ExternalComms = externalComms;
        }
        public ResultValue<List<Product>> GetSortedProducts(string resource, string sortOption, string token)
        {
            var result = ExternalComms.GetExercise2Response(resource, token);
            
            if (result.IsOk)
            {
                List<Product> sortedResult = new List<Product>();
                switch (sortOption)
                {
                    case SortingType.Low:
                        sortedResult = result.Value.OrderBy(x => x.price).ToList();
                        break;
                    case SortingType.High:
                        sortedResult = result.Value.OrderByDescending(x => x.price).ToList();
                        break;
                    case SortingType.Ascending:
                        sortedResult = result.Value.OrderBy(x => x.name).ToList();
                        break;
                    case SortingType.Descending:
                        sortedResult = result.Value.OrderByDescending(x => x.name).ToList();
                        break;
                    case SortingType.Recommended:
                        var shopperHistory = ExternalComms.GetShopperHistory(token);
                        var flattentedProducts = shopperHistory.Value.SelectMany(x => x.products).ToList();
                        var counts = flattentedProducts.GroupBy(x => x.name).Select(x => new { name = x.Key, Count = x.Count() });
                        var sortedProducts = counts.OrderByDescending(x => x.Count);
                        foreach(var p in sortedProducts)
                        {
                            var product = flattentedProducts.First(x => x.name == p.name);
                            sortedResult.Add(new Product()
                            {
                                name = product.name,
                                price = product.price,
                                quantity = product.quantity
                            });
                        }
                        break;
                    default:
                        return Result.Failed<List<Product>>(Error.CreateFrom("InvalidSorting", ErrorType.InvalidSortingParameter));

                }
                return Result.Ok(sortedResult);
            }
            else
            {
                return result;
            }
        }


    }
}
