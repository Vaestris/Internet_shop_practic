using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_test.interfaces
{
    public interface IGetProducts
    {
        IEnumerable<Product> AllProducts { get; }
        Product getproductid(int id);
        
    }
}
