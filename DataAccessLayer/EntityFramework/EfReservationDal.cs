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
	
	public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
	{
		
		public List<Reservation> GetListWithReservationByAccepted(int id)
		{
			using (var context = new Context())
			{
				return context.Reservations.Include(x=>x.Destinations).Where(x=>x.Status == "Aktif Rezervasyon" && x.AppUserId == id).ToList();
			}
		}

		public List<Reservation> GetListWithReservationByPrevious(int id)
		{
			using (var context = new Context())
			{
				return context.Reservations.Include(x => x.Destinations).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
			}
		}

		public List<Reservation> GetListWithReservationByWaitApproval(int id)
		{
			using (var context = new Context())
			{
				return context.Reservations.Include(x=>x.Destinations).Where(x=>x.Status=="Onay Bekliyor" && x.AppUserId == id).ToList(); //destinations ve reservations için ilişkilendirme yaptık ve sonrasında reservations datanın içinde
																																		  //statuyü onay bekliyor olan ile çağırabilmemiz için sayfamıza bu komutları yazmış olduk
			}
		}
	}
}
