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
    public class SaleService
    {

        private readonly ISaleRepository _saleRepo;
        private readonly ICustomerRepository _customerRepo;

        public SaleService(ISaleRepository saleRepo, ICustomerRepository customerRepo, ISaleStoreProductRepository saleStoreProductRepo)
        {
            _saleRepo = saleRepo;
            _customerRepo = customerRepo;
        }

        public int Add(SaleDto sale)
        {
            var customer = _customerRepo.Get(sale.Customer.Id);

            var entity = Mapper.MapSaleDtoToEntity(sale);
            entity.Customer = customer;

            return _saleRepo.Add(entity);
        }

        public List<SaleDto> GetAll()
        {
            return _saleRepo.GetAll()
                .Include(s => s.Customer)
                .Select(s => Mapper.MapSaleEntityToDto(s))
                .ToList();
        }

        public void Update(SaleDto saleDto)
        {
            var entity = _saleRepo.Get(saleDto.Id);
            entity.Status = saleDto.Status;

            _saleRepo.Update(entity);
        }

        //public ProductDto Get(int id)
        //{
        //    var entity = _saleRepo.Get(id);
        //    return Mapper.MapProductEntityToDto(entity);
        //}

        //public IEnumerable<ProductDto> GetAll()
        //{
        //    var entities = _saleRepo.GetAll().ToList();

        //    return entities.Select(p => Mapper.MapProductEntityToDto(p));
        //}

        //public void RemoveById(int id)
        //{
        //    var entity = _saleRepo.Get(id);

        //    _saleRepo.Delete(entity);
        //}

        //public void Update(ProductDto sale)
        //{
        //    var entity = _saleRepo.Get(sale.Id);
        //    entity.Name = sale.Name;

        //    _saleRepo.Update(entity);
        //}
    }
}
