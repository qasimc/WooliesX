using System;
using System.Collections.Generic;
using System.Text;
using WooliesX.Domain.Models;
using WooliesX.Service.Interfaces;
using System.Linq;

namespace WooliesX.Services
{
    public class Exercise3Service : IExercise3Service
    {
        public ResultValue<double> CalculateMinimumTrolleyTotal(List<SpecialsGroup> specials, List<Product> products, List<Quantity> trolleyQuantities)
        {
            try
            {
                List<Quantity> tempTrolley = trolleyQuantities;
                List<TrolleyTotalsWithSpecials> totalsWithSpecials = new List<TrolleyTotalsWithSpecials>();
                double trolleyTotal = 0;
                foreach (var item in tempTrolley)
                {
                    IEnumerable<Quantity> specialOffer = specials.SelectMany(x => x.quantities).Where(x => x.name == item.name && item.quantity >= x.quantity); ;
                    if (specialOffer.Any())
                    {
                        ApplySpecials(specials, products, totalsWithSpecials, item, specialOffer);
                    }
                    else
                    {
                        totalsWithSpecials.Add(new TrolleyTotalsWithSpecials()
                        {
                            itemName = item.name,
                            quantity = item.quantity,
                            billAmount = products.First(x => x.name == item.name).price * item.quantity
                        });
                    }
                }

                foreach (var a in totalsWithSpecials)
                {
                    trolleyTotal += a.billAmount;
                }

                return Result.Ok(trolleyTotal);
            }catch(Exception ex)
            {
                return Result.Failed<double>(Error.CreateFrom("Calculate Trolley Total Error", ErrorType.ErrorCalculatingTrolleyTotal, ex.Message));
            }
        }

        private static void ApplySpecials(List<SpecialsGroup> specials, List<Product> products, List<TrolleyTotalsWithSpecials> totalsWithSpecials, Quantity item, IEnumerable<Quantity> isOnSpecial)
        {
            do
            {
                int group = item.quantity / isOnSpecial.Max(x => x.quantity);
                int remainingQuantity = item.quantity % isOnSpecial.Max(x => x.quantity);
                totalsWithSpecials.Add(new TrolleyTotalsWithSpecials()
                {
                    itemName = item.name,
                    quantity = group,
                    billAmount = specials.Where(p => p.quantities.Any(y => y.name == item.name && y.quantity == isOnSpecial.Max(x => x.quantity))).First().total * group
                });
                item.quantity = remainingQuantity;
                isOnSpecial = specials.SelectMany(x => x.quantities).Where(x => x.name == item.name && item.quantity >= x.quantity);
            } while (isOnSpecial.Any() && item.quantity >= isOnSpecial.Max(x => x.quantity));
            if (item.quantity > 0)
            {
                totalsWithSpecials.Add(new TrolleyTotalsWithSpecials()
                {
                    itemName = item.name,
                    quantity = item.quantity,
                    billAmount = products.First(x => x.name == item.name).price * item.quantity
                });
            }

            
        }
    }

    public class TrolleyTotalsWithSpecials
    {
        public string itemName { get; set; }
        public double quantity { get; set; }
        public double billAmount { get; set; }
    }
}
