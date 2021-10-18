using CIA.Core.Entities;
using CIA.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Helpers
{
    public static class Mapper
    {
        public static StoreEntity MapStoreDtoToEntity(StoreDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static StoreDto MapStoreEntityToDto(StoreEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static SaleStoreProductEntity MapSaleStoreProductDtoToEntity(SaleStoreProductDto dto)
        {
            return new()
            {
                Sale = MapSaleDtoToEntity(dto.Sale),
                StoreProduct = MapStoreProductDtoToEntity(dto.StoreProduct),
                Quantity = dto.Quantity
            };
        }

        public static SaleEntity MapSaleDtoToEntity(SaleDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Customer = MapCustomerDtoToEntity(dto.Customer),
                Status = dto.Status,
                TotalPrice = dto.TotalPrice
            };
        }

        public static SaleDto MapSaleEntityToDto(SaleEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                Customer = MapCustomerEntityToDto(entity.Customer),
                Status = entity.Status,
                TotalPrice = entity.TotalPrice
            };
        }


        public static CustomerEntity MapCustomerDtoToEntity(CustomerDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                Birthdate = dto.Birthdate,
                Gender = dto.Gender
            };
        }

        public static CustomerDto MapCustomerEntityToDto(CustomerEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name,
                Address = entity.Address,
                Birthdate = entity.Birthdate,
                Gender = entity.Gender
            };
        }

        public static ProductEntity MapProductDtoToEntity(ProductDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Name = dto.Name
            };
        }

        public static ProductDto MapProductEntityToDto(ProductEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static StoreProductEntity MapStoreProductDtoToEntity(StoreProductDto dto)
        {
            return new()
            {
                Id = dto.Id,
                Store = MapStoreDtoToEntity(dto.Store),
                Product = MapProductDtoToEntity(dto.Product),
                Price = dto.Price,
                Quantity = dto.Quantity
            };
        }

        public static StoreProductDto MapStoreProductEntityToDto(StoreProductEntity entity)
        {
            return new()
            {
                Id = entity.Id,
                Store = MapStoreEntityToDto(entity.Store),
                Product = MapProductEntityToDto(entity.Product),
                Price = entity.Price,
                Quantity = entity.Quantity
            };
        }
    }
}
