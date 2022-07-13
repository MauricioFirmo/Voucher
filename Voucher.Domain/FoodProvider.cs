using System;
using System.Collections.Generic;
using System.Text;

namespace Voucher.Domain
{
    public class FoodProvider : ServiceProvider
    {
        public decimal Price { get; set; }
        public MealType MealType { get; set; }
    }
}
