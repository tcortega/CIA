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

        public static ProductEntity MapProductDtoToEntity(ProductDto dto)
        {
            return new()
            {
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

    }
}
