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
    public class SaleStoreProductService
    {

        private readonly ISaleStoreProductRepository _saleStoreProductRepo;
        private readonly ISaleRepository _saleRepo;
        private readonly IStoreProductRepository _storeProductRepo;

        public SaleStoreProductService(ISaleStoreProductRepository saleStoreProductRepo, ISaleRepository saleRepo, IStoreProductRepository storeProductRepo)
        {
            _saleStoreProductRepo = saleStoreProductRepo;
            _saleRepo = saleRepo;
            _storeProductRepo = storeProductRepo;
        }

        public void Add(SaleStoreProductDto saleStoreProduct)
        {
            var entity = Mapper.MapSaleStoreProductDtoToEntity(saleStoreProduct);
            entity.Sale = _saleRepo.Get(entity.Sale.Id);
            entity.StoreProduct = _storeProductRepo.Get(entity.StoreProduct.Id);

            _saleStoreProductRepo.Add(entity);
        }

        public void Add(IEnumerable<SaleStoreProductDto> saleStoreProduct)
        {
            var entities = saleStoreProduct.Select(s => Mapper.MapSaleStoreProductDtoToEntity(s)).ToList();
            var sale = _saleRepo.Get(entities.First().Sale.Id);

            foreach (var entity in entities)
            {
                entity.Sale = sale;
                entity.StoreProduct = _storeProductRepo.Get(entity.StoreProduct.Id);
            }

            _saleStoreProductRepo.Add(entities);

            foreach(var entity in entities)
            {
                entity.StoreProduct.Quantity -= entity.Quantity;
                _storeProductRepo.Update(entity.StoreProduct);
            }
        }

        public void CancelSaleProducts(int saleId)
        {
            var entities = _saleStoreProductRepo.GetAll()
                .Include(x => x.Sale)
                .Include(x => x.StoreProduct)
                .Where(x => x.Sale.Id == saleId)
                .ToList();

            foreach (var entity in entities)
            {
                entity.StoreProduct.Quantity += entity.Quantity;
                _storeProductRepo.Update(entity.StoreProduct);
            }
        }
    }
}
