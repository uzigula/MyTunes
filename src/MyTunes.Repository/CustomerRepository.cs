using System;
using System.Data.Entity;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class CustomerRepository : BaseRepository<Customer, ChinookContext>
    {
        public CustomerRepository(ChinookContext context)
            : base(context)
        {
        }
    }
}
