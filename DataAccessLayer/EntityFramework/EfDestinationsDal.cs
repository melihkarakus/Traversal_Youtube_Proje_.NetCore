using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfDestinationsDal : GenericRepository<Destinations>, IDestinationDal
    {
        public Destinations GetDestinationWithGuide(int id)
        {
           using (var c = new Context())
            {
                return c.Destinations.Where(x=>x.DestinationsID == id).Include(x=>x.Guide).FirstOrDefault();
            }
        }
    }
}
