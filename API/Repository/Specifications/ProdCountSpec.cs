using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Specifications
{
    public class ProdCountSpec : BaseSpecification<Product>
    {
        public ProdCountSpec(ProdSpecParams ProdParams)
            : base(x =>
                (!ProdParams.TypeId.HasValue || x.ProductTypeId == ProdParams.TypeId)
            )
        {
        }
    }
}
