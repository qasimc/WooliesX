using System;
using System.Collections.Generic;
using System.Text;

namespace WooliesX.Domain.Models
{
    public class ErrorType
    {
        public readonly string Type;
        public readonly string Title;

        private ErrorType(string type, string title)
        {
            Type = type;
            Title = title;
        }
        public static readonly ErrorType InternalServerError = new ErrorType("InternalServerError", "There was an internal server error");
        public static readonly ErrorType InvalidSortingParameter = new ErrorType("InvalidSortingParameter", "An invalid sorting parameter was supplied.");
        public static readonly ErrorType ErrorFetchingProducts = new ErrorType("ErrorFetchingProducts", "An error occured while trying to fetch products.");
        public static readonly ErrorType ErrorFetchingShopperHistory = new ErrorType("ErrorFetchingShopperHistory", "An error occured while trying to fetch shopper history.");
        public static readonly ErrorType ErrorCalculatingTrolleyTotal = new ErrorType("ErrorCalculatingTrolleyTotal", "An error occured while trying to calculate trolley total.");
    }

}
