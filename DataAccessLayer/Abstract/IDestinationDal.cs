using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal : IGenericDal<Destinations>
    {
        public Destinations GetDestinationWithGuide(int id);
        public List<Destinations> GetLast4Destinations();
    }
}
