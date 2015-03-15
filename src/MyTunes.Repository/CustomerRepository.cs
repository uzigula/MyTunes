using MyTunes.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunes.Repository
{
    public class CustomerRepository : IDisposable
    {
        private ChinookContext _context;
        public CustomerRepository()
        {
            _context = new ChinookContext();
        }
        public Customer GetByEmail(string userName)
        {
            return _context.Customer.FirstOrDefault(x => x.Email == userName);
        }

        public void Dispose()
        {
            _context = null;
        }

        public int Create(Customer customer)
        {
            _context.Customer.Add(customer);
           return  _context.SaveChanges();
        }
    }
}
