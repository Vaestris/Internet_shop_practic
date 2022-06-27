using Internet_shop_practic.Models;
using System.Collections.Generic;

namespace Internet_shop_practic.interfaces
{
    public interface IGetCustomers
    {
        
        IEnumerable<Customer> AllCustomers { get;  }
       
    }
}
