using System.Collections.Generic;
using Internet_shop_practic.interfaces;
using Internet_shop_practic.Models;

namespace Internet_shop_practic.Repository
{
    public class GetCustomers : IGetCustomers
    {
        private readonly DBmodel ProgramContext;


        public GetCustomers(DBmodel ProgramContext)
        {
            this.ProgramContext = ProgramContext;
        }

         public IEnumerable<Customer> AllCustomers => ProgramContext.Customers;

    }
}
