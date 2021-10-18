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
    public class InventoryService
    {
        private readonly IInventoryRepository _inventoryRepo;

        public InventoryService(IInventoryRepository inventoryRepo)
        {
            _inventoryRepo = inventoryRepo;
        }

        public void AddInventory(InventoryDto inventory)
        {
            _inventoryRepo.Add(Mapper.MapInventoryDtoToEntity(inventory));
        }

        public IEnumerable<InventoryDto> GetAllInventories()
        {
            var entities = _inventoryRepo.GetAll().ToList();

            return entities.Select(s => Mapper.MapInventoryEntityToDto(s));
        }

        public void RemoveById(int id)
        {
            var entity = _inventoryRepo.Get(id);

            _inventoryRepo.Delete(entity);
        }
    }
}
