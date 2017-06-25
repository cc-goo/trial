using refactor_me.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using refactor_me.Persistence;

namespace refactor_me.Core.Domain.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork = new UnitOfWork(new ProductApplicationContext());

        //public ProductsController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        [Route]
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _unitOfWork.Products.GetAll();
        }

        [Route]
        [HttpGet]
        public IEnumerable<Product> SearchByName(string name)
        {
            return _unitOfWork.Products.Find(p => String.Equals(p.Name, name) );
        }

        [Route("{id}")]
        [HttpGet]
        public Product GetProduct(Guid id)
        {
            var product = _unitOfWork.Products.Get(id);

            if (product == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return product;
        }

        [Route]
        [HttpPost]
        public void Create(Product product)
        {
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
        }

        [Route("{id}")]
        [HttpPut]
        public void Update(Guid id, Product product)
        {
            var existingProduct = _unitOfWork.Products.Get(id);

            if (existingProduct == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.DeliveryPrice = product.DeliveryPrice;

            _unitOfWork.Complete();
        }

        [Route("{id}")]
        [HttpDelete]
        public void Delete(Guid id)
        {
            var existingProduct = _unitOfWork.Products.Get(id);

            if (existingProduct == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _unitOfWork.Products.Remove(existingProduct);
            _unitOfWork.Complete();
        }

        [Route("{productId}/options")]
        [HttpGet]
        public IEnumerable<ProductOption> GetOptions(Guid productId)
        {
            var existingProduct = _unitOfWork.Products.Get(productId);

            if (existingProduct == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return _unitOfWork.Products.GetProductOptionsOfProduct(existingProduct);
        }

        [Route("{productId}/options/{id}")]
        [HttpGet]
        public ProductOption GetOption(Guid productId, Guid id)
        {
            var existingProduct = _unitOfWork.Products.Get(productId);

            if (existingProduct == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return _unitOfWork.Products.GetProductOptionsOfProductByProductOptionId(existingProduct, id);
        }

        [Route("{productId}/options")]
        [HttpPost]
        public void CreateOption(Guid productId, ProductOption productOption)
        {
            var existingProduct = _unitOfWork.Products.Get(productId);

            if (existingProduct == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var existingProductOption = _unitOfWork.Products.GetProductOptionsOfProductByProductOptionId(existingProduct, productOption.Id);

            if (existingProductOption != null)
                //todo cannot create
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var newProductOption = new ProductOption()
                {
                    Id = productOption.Id,
                    Name = productOption.Name,
                    Description = productOption.Description,
                    ProductId = productId
                };

            _unitOfWork.ProductOptions.Add(newProductOption);
            _unitOfWork.Complete();
        }

        [Route("{productId}/options/{id}")]
        [HttpPut]
        public void UpdateOption(Guid productId, Guid id, ProductOption productOption)
        {
            var existingProduct = _unitOfWork.Products.Get(productId);

            if (existingProduct == null)
            throw new HttpResponseException(HttpStatusCode.NotFound);

            var existingProductOption = _unitOfWork.Products.GetProductOptionsOfProductByProductOptionId(existingProduct, id);

            if (existingProductOption == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
       
            existingProductOption.Name = productOption.Name;
            existingProductOption.Description = productOption.Description;

            _unitOfWork.Complete();
    }

        [Route("{productId}/options/{id}")]
        [HttpDelete]
        public void DeleteOption(Guid productId, Guid id)
        {
            var existingProduct = _unitOfWork.Products.Get(productId);

            if (existingProduct == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var existingProductOption = _unitOfWork.Products.GetProductOptionsOfProductByProductOptionId(existingProduct, id);

            if (existingProductOption == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _unitOfWork.ProductOptions.Remove(existingProductOption);
            _unitOfWork.Complete();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
