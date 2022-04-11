using System;
using System.Collections.Generic;
using System.Linq;

using Internet_shop_practic.interfaces;
using Internet_shop_practic.Models;
using Microsoft.EntityFrameworkCore;

namespace Internet_shop_practic.Repository
{
    public class GetCustomers : IGetCustomers
    {
        private readonly ProgramContext ProgramContext;


        public GetCustomers(ProgramContext ProgramContext)
        {
            this.ProgramContext = ProgramContext;
        }

         public IEnumerable<Customer> AllCustomers => ProgramContext.Customers;

    }
}
