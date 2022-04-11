using Internet_shop_practic.interfaces;
using Internet_shop_practic.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Internet_shop_practic.Repository
{
    public class GetProducts : IGetProducts
    {
        private readonly ProgramContext ProgramContext;
        public GetProducts(ProgramContext ProgramContext)
        {
            this.ProgramContext = ProgramContext;
        }

       

        public IEnumerable<Product> AllProducts => ProgramContext.Products;



             
    }
}
