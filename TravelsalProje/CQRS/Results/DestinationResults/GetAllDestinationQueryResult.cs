namespace TravelsalProje.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult //burada bizim databasedeki veri başlıkları ve veri içerikleri tutucak
    {
        public int id { get; set; }
        public string city { get; set; }
        public string daynight { get; set; }
        public double price { get; set; }
        public int capacity  { get; set; }
    }
}
