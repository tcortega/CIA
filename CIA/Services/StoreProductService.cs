using CIA.Core.Entities;
using CIA.Core.Repositories;
using CIA.DTOs;
using CIA.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Services
{
    public class StoreProductService
    {
        private readonly IStoreProductRepository _storeProductRepo;
        private readonly IProductRepository _productRepo;
        private readonly IStoreRepository _storeRepo;
        private readonly ISaleStoreProductRepository _saleStoreProductRepo;

        public StoreProductService(IStoreProductRepository storeProductRepo, IProductRepository productRepo, IStoreRepository storeRepo,
            ISaleStoreProductRepository saleStoreProductRepo)
        {
            _storeProductRepo = storeProductRepo;
            _productRepo = productRepo;
            _storeRepo = storeRepo;
            _saleStoreProductRepo = saleStoreProductRepo;
        }

        public void Add(StoreProductDto storeProduct)
        {
            var storeProductEntity = Mapper.MapStoreProductDtoToEntity(storeProduct);
            storeProductEntity.Product = _productRepo.Get(storeProduct.Product.Id);
            storeProductEntity.Store = _storeRepo.Get(storeProduct.Store.Id);

            _storeProductRepo.Add(storeProductEntity);
        }

        public List<StoreProductDto> GetAllByStoreId(int id)
        {
            var entities = _storeProductRepo.GetAll()
                .Include(e => e.Product)
                .Where(x => x.Store.Id == id);

            return entities.Select(s => Mapper.MapStoreProductEntityToDto(s)).ToList();
        }

        public void RemoveById(int id)
        {
            var entity = _storeProductRepo.Get(id);
            if (entity != null)
            {
                _storeProductRepo.Delete(entity);
            }
        }

        public void Update(StoreProductDto storeProduct)
        {
            var storeEntity = _storeRepo.Get(storeProduct.Store.Id);
            var productEntity = _productRepo.Get(storeProduct.Product.Id);

            var entity = _storeProductRepo.Get(storeProduct.Id);
            entity.Store = storeEntity;
            entity.Product = productEntity;
            entity.Price = storeProduct.Price;
            entity.Quantity = storeProduct.Quantity;

            _storeProductRepo.Update(entity);
        }

        public bool ExistsByStoreId(int id)
        {
            var entities = _storeProductRepo.GetAll()
                .Where(x => x.Store.Id == id);

            return entities.Count() > 0;
        }
    }
}
