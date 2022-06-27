using Internet_shop_practic.Models;
using System.Collections.Generic;

namespace Internet_shop_practic.interfaces
{
    interface IGetOrders
    {
        IEnumerable<Order> AllOrders { get;  }
    }
}
