using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.Repository.Specifications
{
    public class ProdWithTypesSpec : BaseSpecification<Product>
    {
        public ProdWithTypesSpec(ProdSpecParams ProdParams)
            : base(x =>
                (!ProdParams.TypeId.HasValue || x.ProductTypeId == ProdParams.TypeId)
            )
        {
            AddInclude(z => z.ProductType);
            AddOrderBy(x => x.Name);
            ApplyPaging(ProdParams.PageSize * (ProdParams.PageIndex - 1), ProdParams.PageSize);

            if (!string.IsNullOrEmpty(ProdParams.Sort))
            {
                switch (ProdParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(d => d.Name);
                        break;
                }
            }
        }

        public ProdWithTypesSpec(int id) : base(o => o.Id == id)
        {
            AddInclude(z => z.ProductType);
        }
    }
}
