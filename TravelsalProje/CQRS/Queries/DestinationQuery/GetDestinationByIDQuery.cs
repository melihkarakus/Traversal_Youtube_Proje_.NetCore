namespace TravelsalProje.CQRS.Queries.DestinationQuery
{
    public class GetDestinationByIDQuery
    {
        public GetDestinationByIDQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; } // parametre olarak gönderilecek id olacak
    }
}
