using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using refactor_me.Core.Domain.Models;
using refactor_me.Core.Repositories;

namespace refactor_me.Persistence.Repositories
{
    public class ProductOptionRepository : Repository<ProductOption>, IProductOptionRepository
    {
        public ProductApplicationContext ProductApplicationContext
        {
            get
            {
                return Context as ProductApplicationContext;
            }
        }
        public ProductOptionRepository(ProductApplicationContext context)
            : base(context)
        {
        }

    }
}