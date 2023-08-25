using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Queries.ALL;
using HandBallTournamentv2.DataAccess.Entities;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Match
{
    public class GetMatchesHandler : IRequestHandler<GetMatchesRequest, GetMatchesResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetMatchesHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetMatchesResponse> Handle(GetMatchesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMatchesQuery()
            {
                MatchAudience = request.MaxMatchAudience,
                MatchTicketCost = request.MaxMatchTicketCost
            };
            var matches = await queryExecutor.Execute(query);
            var mappedMatches = mapper.Map<List<DTO_Match>>(matches);

            var response = new GetMatchesResponse()
            {
                Data = mappedMatches
            };

            return response;
        }
    }
}
