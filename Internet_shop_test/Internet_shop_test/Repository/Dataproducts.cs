using Internet_shop_test.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Internet_shop_test.Repository
{
    public class Dataproducts : IGetProducts
    {
        private readonly ProgramContext ProgramContext;
        public Dataproducts(ProgramContext ProgramContext)
        {
            this.ProgramContext = ProgramContext;
        }

        //public IEnumerable<product> AllCategories => throw new NotImplementedException();

        public IEnumerable<Product> AllProducts => ProgramContext.products.Include(c => c.existence);



        public Product getproductid(int id) => ProgramContext.products.FirstOrDefault(p => p.id == id);

    }
}
