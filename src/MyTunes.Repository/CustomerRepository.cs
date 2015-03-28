using System;
using System.Data.Entity;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class CustomerRepository : IRepository<Customer>
    {
        private ChinookContext _context;
        public CustomerRepository(DbContext context)
        {
            _context = (ChinookContext)(context);
        }
        public Customer GetByEmail(string userName)
        {
            return _context.Customer.FirstOrDefault(x => x.Email == userName);
        }

        public void Dispose()
        {
            _context = null;
        }

        public IQueryable<Customer> Get()
        {
            return _context.Customer.AsQueryable();
        }

        public void Create(Customer playList)
        {
            _context.Customer.Add(playList);
            _context.SaveChanges();
        }

        public void Update(Customer playList)
        {
            _context.SaveChanges();
        }
    }
}
