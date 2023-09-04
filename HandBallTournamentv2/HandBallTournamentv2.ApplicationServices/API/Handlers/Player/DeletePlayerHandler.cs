using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.ApplicationServices.API.Domain.Player;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.DELETE;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Player
{
    public class DeletePlayerHandler : IRequestHandler<DeletePlayerByIdRequest, DeletePlayerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeletePlayerHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeletePlayerByIdResponse> Handle(DeletePlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerQuery() { PlayerId = request.Id };
            var playerToDelete = await queryExecutor.Execute(query);
            var command = new DeletePlayerCommand() { Parameter = playerToDelete };
            var deletedPlayer = await commandExecutor.Execute(command);
            var response = new DeletePlayerByIdResponse()
            {
                Data = mapper.Map<PlayerDto>(deletedPlayer)
            };
            return response;
        }
    }
}
