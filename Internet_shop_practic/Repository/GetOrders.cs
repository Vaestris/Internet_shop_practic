using System.Collections.Generic;
using Internet_shop_practic.interfaces;
using Internet_shop_practic.Models;

namespace Internet_shop_practic.Repository
{
    public class GetOrders : IGetOrders
    {
        private readonly DBmodel ProgramContext;


        public GetOrders(DBmodel ProgramContext)
        {
            this.ProgramContext = ProgramContext;
        }

        public IEnumerable<Order> AllOrders => ProgramContext.Orders;

      
    }
}
