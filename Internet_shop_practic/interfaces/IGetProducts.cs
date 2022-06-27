using Internet_shop_practic.Models;
using System.Collections.Generic;

namespace Internet_shop_practic.interfaces
{
    public interface IGetProducts
    {
        IEnumerable<Product> AllProducts { get; }
        
        
    }
}
