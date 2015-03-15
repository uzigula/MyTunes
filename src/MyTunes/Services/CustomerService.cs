using MyTunes.Dominio;
using MyTunes.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunes.Services
{
    public class CustomerService
    {
        private CustomerRepository _customerRepository;
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public void Create(Models.CustomerViewModel customerViewModel)
        {
            // customerViewModel -> Customer
            var customer = new Customer
            {
                FirstName = customerViewModel.FirstName,
                LastName = customerViewModel.LastName,
                Email = customerViewModel.Email
            };
            // Tratamiento de Errores, traducir el error para UI
            _customerRepository.Create(customer);
            
        }
    }
}
