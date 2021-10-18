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
    public class CustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public void AddCustomer(CustomerDto customer)
        {
            _customerRepo.Add(Mapper.MapCustomerDtoToEntity(customer));
        }

        public List<CustomerDto> GetAll()
        {
            var entities = _customerRepo.GetAll();

            return entities.Select(c => Mapper.MapCustomerEntityToDto(c)).ToList();
        }

        public void RemoveById(int id)
        {
            var entity = _customerRepo.Get(id);

            _customerRepo.Delete(entity);
        }

        public void Update(CustomerDto customer)
        {
            var entity = _customerRepo.Get(customer.Id);
            entity.Name = customer.Name;
            entity.Address = customer.Address;
            entity.Birthdate = customer.Birthdate;
            entity.Gender = customer.Gender;

            _customerRepo.Update(entity);
        }
    }
}
