using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazingo_Core.Domain_Logic
{
    public static class ProductLogic
    {
        public static decimal CalculateDiscount(decimal price , int quantity)
        {
            if (quantity > 10)
                return price * 0.9M; // خصم 10% إذا تجاوز الكمية 10

            return price;
        }
    }
}
