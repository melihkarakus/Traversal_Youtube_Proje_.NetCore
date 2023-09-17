using MediatR;
using TravelsalProje.CQRS.Results.GuideResults;

namespace TravelsalProje.CQRS.Queries.GuideQuery
{
    public class GetGuideByIDQuery : IRequest<GetGuideByIDQueryResult>
    {
        public GetGuideByIDQuery(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
