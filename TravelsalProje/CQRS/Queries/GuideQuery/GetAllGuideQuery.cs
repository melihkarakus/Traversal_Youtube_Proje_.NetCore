using MediatR;
using System.Collections.Generic;
using TravelsalProje.CQRS.Results.GuideResults;

namespace TravelsalProje.CQRS.Queries.GuideQuery
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
