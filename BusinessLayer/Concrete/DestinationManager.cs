using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DestinationManager : IDestinationsService
    {
        IDestinationDal _destinationDal;

        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public List<Destinations> TGetLast4Destinations()
        {
            return _destinationDal.GetLast4Destinations();
        }

        public void TAdd(Destinations t)
        {
            _destinationDal.Insert(t);
        }

        public void TDelete(Destinations t)
        {
            _destinationDal.Delete(t);
        }

        public Destinations TGetByID(int id)
        {
            return _destinationDal.GetByID(id);
        }

        public Destinations TGetDestinationWithGuide(int id)
        {
            return _destinationDal.GetDestinationWithGuide(id);
        }

        public List<Destinations> TGetlist()
        {
           return _destinationDal.GetList();
        }

        public void TUpdate(Destinations t)
        {
            _destinationDal.Update(t);
        }
    }
}
