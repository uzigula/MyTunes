using System;
using System.Data.Entity;
using System.Linq;
using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(DbContext context):base(context)
        {
        }
    }
}
