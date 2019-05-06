using DomainCore;
using DomainServices.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices
{
    public class CustomerBO
    {
        ICustomerRepository repository;

        public CustomerBO(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public string GetCustomerDeliveryAddress(int id)
        {
            return repository.Get(id).DeliveryAddress;
        }
    }
}
