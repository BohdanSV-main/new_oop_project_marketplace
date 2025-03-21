using System;
using System.Collections.Generic;
using System.Linq;

namespace Marketplace
{
    public static class ProductSorter
    {
        public static List<Product> Sort(List<Product> products, string criteria)
        {
            return criteria switch
            {
                "За ціною (дешеві → дорогі)" => products.OrderBy(p => p.Price).ToList(),
                "За ціною (дорогі → дешеві)" => products.OrderByDescending(p => p.Price).ToList(),
                "За назвою (A → Z)" => products.OrderBy(p => p.Name).ToList(),
                "За назвою (Z → A)" => products.OrderByDescending(p => p.Name).ToList(),
                _ => products
            };
        }
    }
}
