using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Http;
using refactor_me.Core.Domain.Models;
using refactor_me.Core.Repositories;

namespace refactor_me.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductApplicationContext ProductApplicationContext
        {
            get
            {
                return Context as ProductApplicationContext;
            }
        }
        public ProductRepository(ProductApplicationContext context)
            :base(context)
        {
            
        }

        public IEnumerable<ProductOption> GetProductOptionsOfProduct(Product product)
        {
            ProductApplicationContext.Entry(product).Collection(p => p.ProductOptions).Load();

            return product.ProductOptions;
        }

        public ProductOption GetProductOptionsOfProductByProductOptionId(Product product, Guid productOptionId)
        {
            ProductApplicationContext.Entry(product).Collection(p => p.ProductOptions).Load();

            return product.ProductOptions.SingleOrDefault(po => po.Id == productOptionId);
        }

        public ProductOption AddProductOptionsOfProduct(Guid productId, Guid productOptionId)
        {
            var product = ProductApplicationContext.Products.Find(productId);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            ProductApplicationContext.Entry(product).Collection(p => p.ProductOptions).Load();

            return product.ProductOptions.SingleOrDefault(po => po.Id == productOptionId);
        }

        //public void UpdateProductOptionOfProductByProductOptionId(Guid productId, Guid productOptionId)
        //{
        //    var product = ProductApplicationContext.Products.Find(productId);

        //    if (product == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    ProductApplicationContext.Entry(product).Collection(p => p.ProductOptions).Load();

        //    return product.ProductOptions.SingleOrDefault(po => po.Id == productOptionId);
        //}

        //public ProductOption RemoveProductOptionsOfProductByProductOptionId(Guid productId, Guid productOptionId)
        //{
        //    var product = ProductApplicationContext.Products.Find(productId);

        //    if (product == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    ProductApplicationContext.Entry(product).Collection(p => p.ProductOptions).Load();

        //    return product.ProductOptions.SingleOrDefault(po => po.Id == productOptionId);
        //}



    }
}