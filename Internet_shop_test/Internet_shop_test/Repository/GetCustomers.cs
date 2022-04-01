using System;
using System.Collections.Generic;
using System.Linq;

using Internet_shop_test.interfaces;

using Microsoft.EntityFrameworkCore;

namespace Internet_shop_test.Repository
{
    public class GetCustomers : IGetCustomers
    {
        private readonly ProgramContext ProgramContext;


        public GetCustomers(ProgramContext ProgramContext)
        {
            this.ProgramContext = ProgramContext;
        }

         public IEnumerable<Customer> AllCustomers => ProgramContext.customers;

    }
}
