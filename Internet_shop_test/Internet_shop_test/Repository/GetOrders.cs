using System;
using System.Collections.Generic;
using System.Linq;

using Internet_shop_test.interfaces;

using Microsoft.EntityFrameworkCore;

namespace Internet_shop_test.Repository
{
    public class GetOrders : IGetOrders
    {
        private readonly ProgramContext ProgramContext;


        public GetOrders(ProgramContext ProgramContext)
        {
            this.ProgramContext = ProgramContext;
        }

        public IEnumerable<Order> AllOrders => ProgramContext.orders;

      
    }
}
