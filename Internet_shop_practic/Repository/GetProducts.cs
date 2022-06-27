using Internet_shop_practic.interfaces;
using Internet_shop_practic.Models;
using System.Collections.Generic;

namespace Internet_shop_practic.Repository
{
    public class GetProducts : IGetProducts
    {
        private readonly DBmodel ProgramContext;
        public GetProducts(DBmodel ProgramContext)
        {
            this.ProgramContext = ProgramContext;
        }

       

        public IEnumerable<Product> AllProducts => ProgramContext.Products;



             
    }
}
