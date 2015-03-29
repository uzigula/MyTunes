using MyTunes.Dominio;
using MyTunes.Models;
using MyTunes.Repository;

namespace MyTunes.Services
{
    public class CustomerService
    {
        private IRepository<Customer>_customerRepository;

        public CustomerService(IRepository<Customer> customerRepository )
        {
            _customerRepository = customerRepository;
        }
        public void Create(CustomerViewModel customerViewModel)
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
