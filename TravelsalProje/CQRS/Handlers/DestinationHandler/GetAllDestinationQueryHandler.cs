using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TravelsalProje.CQRS.Queries.DestinationQuery;
using TravelsalProje.CQRS.Results.DestinationResults;

namespace TravelsalProje.CQRS.Handlers.DestinationHandler
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;//konstrakçır oluşturduk

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        { 
            //context sınıfı bizim database sınıfı oluyor ve destination içinden seçip getirme yapıyoruz
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult //destinationquery result tanımlanan verileri getirdik
            {
                id = x.DestinationsID, //hem database hemde kendi tanımladığımız query result getirip eşitledik
                city = x.City,
                capacity = x.Capacity,
                daynight = x.DayNight,
                price = x.Price
            }).AsNoTracking().ToList();//sadece okunabilir işlemler için AsNoTracking kullanılır.  AsNoTracking kullanıldığında Entity üzerinde değişiklik var mı yok mu  Context tarafından izlemenmez.
            return values;
        }
    }
}
