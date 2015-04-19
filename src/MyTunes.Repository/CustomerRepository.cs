using MyTunes.Dominio;

namespace MyTunes.Repository
{
    public class CustomerRepository : BaseRepository<Customer,ChinookContext>
    {
        public CustomerRepository(ChinookContext context):base(context)
        {
        }
   
    }
}
