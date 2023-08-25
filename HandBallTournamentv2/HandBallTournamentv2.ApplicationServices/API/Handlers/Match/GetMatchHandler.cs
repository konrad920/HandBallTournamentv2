using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Match;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Match
{
    public class GetMatchHandler : IRequestHandler<GetMatchByIdRequest, GetMatchByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetMatchHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetMatchByIdResponse> Handle(GetMatchByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMatchQuery()
            {
                MatchId = request.Id
            };
            var match = await queryExecutor.Execute(query);
            var matchFromDb = mapper.Map<DTO_Match>(match);
            var response = new GetMatchByIdResponse()
            {
                Data = matchFromDb
            };
            return response;
        }
    }
}
