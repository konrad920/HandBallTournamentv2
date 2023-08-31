using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Match;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.PUT;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Match
{
    public class PutMatchHandler : IRequestHandler<PutMatchRequest, PutMatchResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public PutMatchHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }
        public async Task<PutMatchResponse> Handle(PutMatchRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMatchQuery() { MatchId = request.Id };
            var matchToEdit = await queryExecutor.Execute(query);
            var command = new PutMatchCommand()
            {
                Parameter = matchToEdit,
                Audience = request.Audience,
                HostClubId = request.HostClubId,
                HostPoints = request.HostPoints,
                HostScore = request.HostScore,  
                QuestClubId = request.QuestClubId,
                QuestPoints = request.QuestPoints,
                QuestScore = request.QuestScore,
                TicketCost = request.TicketCost
            };
            var editedMatch = await commandExecutor.Execute(command);
            var response = new PutMatchResponse()
            {
                Data = mapper.Map<DTO_Match>(editedMatch)
            };
            return response;
        }
    }
}
