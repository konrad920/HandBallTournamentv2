using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Match;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.DELETE;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Match
{
    public class DeleteMatchHandler : IRequestHandler<DeleteMatchByIdRequest, DeleteMatchByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteMatchHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteMatchByIdResponse> Handle(DeleteMatchByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetMatchQuery() { MatchId = request.Id };
            var matchToDelete = await queryExecutor.Execute(query);
            var command = new DeleteMatchCommand() { Parameter = matchToDelete };
            var deletedMatch = await commandExecutor.Execute(command);
            var response = new DeleteMatchByIdResponse()
            {
                Data = mapper.Map<MatchDto>(deletedMatch)
            };
            return response;
        }
    }
}
