using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Internet_shop_test.interfaces
{
    interface Orders
    {
        IEnumerable<order> AllCategories { set; }
    }
}
