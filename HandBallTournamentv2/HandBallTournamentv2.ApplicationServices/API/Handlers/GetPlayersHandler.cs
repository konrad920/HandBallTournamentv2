using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers
{
    public class GetPlayersHandler : IRequestHandler<GetPlayersRequest, GetPlayersResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPlayersHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetPlayersResponse> Handle(GetPlayersRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayersQuery()
            {
                PlayerPosition = request.PlayerPosition
            };
            var players = await queryExecutor.Execute(query);
            var mappedPlayers = this.mapper.Map<List<Domain.Models.Player>>(players);

            var response = new GetPlayersResponse()
            {
                Data = mappedPlayers
            };

            return response;
        }
    }
}
