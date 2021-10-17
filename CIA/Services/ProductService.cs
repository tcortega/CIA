using CIA.Core.Repositories;
using CIA.DTOs;
using CIA.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Services
{
    public class ProductService
    {

        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public void AddProduct(ProductDto product)
        {
            _productRepo.Add(Mapper.MapProductDtoToEntity(product));
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            var entities = _productRepo.GetAll().ToList();

            return entities.Select(p => Mapper.MapProductEntityToDto(p));
        }

        public void RemoveById(int id)
        {
            var entity = _productRepo.Get(id);

            _productRepo.Delete(entity);
        }
    }
}
