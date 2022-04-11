using Internet_shop_practic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_practic.interfaces
{
    public interface IGetProducts
    {
        IEnumerable<Product> AllProducts { get; }
        
        
    }
}
