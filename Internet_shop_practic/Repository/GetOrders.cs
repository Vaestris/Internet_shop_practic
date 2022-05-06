using System;
using System.Collections.Generic;
using System.Linq;

using Internet_shop_practic.interfaces;
using Internet_shop_practic.Models;
using Microsoft.EntityFrameworkCore;

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
