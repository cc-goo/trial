using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using refactor_me.Core.Domain.Models;

namespace refactor_me.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<ProductOption> GetProductOptionsOfProduct(Product product);
        ProductOption GetProductOptionsOfProductByProductOptionId(Product product, Guid productOptionId);
    }
}
