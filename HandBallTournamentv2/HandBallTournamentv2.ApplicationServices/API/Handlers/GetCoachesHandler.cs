using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers
{
    public class GetCoachesHandler : IRequestHandler<GetCoachesRequest, GetCoachesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCoachesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetCoachesResponse> Handle(GetCoachesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachesQuery();
            var coaches = await queryExecutor.Execute(query);
            var mappedCoaches = this.mapper.Map<List<Domain.Models.Coach>>(coaches);

            var response = new GetCoachesResponse()
            {
                Data = mappedCoaches
            };
            return response;
        }
    }
}
