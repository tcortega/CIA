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

        public void Add(ProductDto product)
        {
            _productRepo.Add(Mapper.MapProductDtoToEntity(product));
        }

        public ProductDto Get(int id)
        {
            var entity = _productRepo.Get(id);
            return Mapper.MapProductEntityToDto(entity);
        }

        public List<ProductDto> GetAll()
        {
            var entities = _productRepo.GetAll();

            return entities.Select(p => Mapper.MapProductEntityToDto(p)).ToList();
        }

        public void RemoveById(int id)
        {
            var entity = _productRepo.Get(id);

            _productRepo.Delete(entity);
        }

        public void Update(ProductDto product)
        {
            var entity = _productRepo.Get(product.Id);
            entity.Name = product.Name;

            _productRepo.Update(entity);
        }
    }
}
