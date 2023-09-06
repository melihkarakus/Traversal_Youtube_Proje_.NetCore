using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ReservationManager : IReservationService
    {
        IReservationDal _reservationDal;

        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

		public List<Reservation> GetListWithReservationByWaitAccepted(int id)
		{
			return _reservationDal.GetListWithReservationByAccepted(id);
		}

		public List<Reservation> GetListWithReservationByWaitApproval(int id)
		{
            return _reservationDal.GetListWithReservationByWaitApproval(id);
		}

		public List<Reservation> GetListWithReservationByWaitPrevios(int id)
		{
			return _reservationDal.GetListWithReservationByPrevious(id);
		}

		public void TAdd(Reservation t)
        {
            _reservationDal.Insert(t);
        }

        public void TDelete(Reservation t)
        {
            throw new NotImplementedException();
        }

        public Reservation TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> TGetlist()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Reservation t)
        {
            throw new NotImplementedException();
        }
    }
}
