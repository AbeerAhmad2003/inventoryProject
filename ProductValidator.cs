using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_Project
{
    public static class ProductValidator
    {
        public static bool IsValid(Product product)
        {
            return !string.IsNullOrWhiteSpace(product.Name)
                &&product.Quantity>=0
                && product.Price>=0;
        }
    }
}
