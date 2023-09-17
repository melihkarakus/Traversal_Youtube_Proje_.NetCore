using DataAccessLayer.Concrete;
using TravelsalProje.CQRS.Queries.DestinationQuery;
using TravelsalProje.CQRS.Results.DestinationResults;

namespace TravelsalProje.CQRS.Handlers.DestinationHandler
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }
        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)//queries içindeki id parametre olarak aldık burada
        {
            var values = _context.Destinations.Find(query.id); //queries içindeki parametreyi çektik
            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationsID, //hem databasedeki veriden alıyor hemde result içindeki veriden alıp eşitliyor
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price,
                Capacity = values.Capacity,
            };
        }
    }
}
