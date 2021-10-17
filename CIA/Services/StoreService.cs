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
    public class StoreService
    {
        private readonly IStoreRepository _storeRepo;

        public StoreService(IStoreRepository storeRepo)
        {
            _storeRepo = storeRepo;
        }

        public void AddStore(StoreDto store)
        {
            _storeRepo.Add(Mapper.MapStoreDtoToEntity(store));
        }

        public IEnumerable<StoreDto> GetAllStores()
        {
            var entities = _storeRepo.GetAll().ToList();

            return entities.Select(s => Mapper.MapStoreEntityToDto(s));
        }

        public void RemoveById(int id)
        {
            var entity = _storeRepo.Get(id);

            _storeRepo.Delete(entity);
        }
    }
}
