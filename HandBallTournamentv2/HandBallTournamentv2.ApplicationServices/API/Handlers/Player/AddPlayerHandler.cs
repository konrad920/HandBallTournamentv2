using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.ADD;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Player
{
    public class AddPlayerHandler : IRequestHandler<AddPlayerRequest, AddPlayerResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddPlayerHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddPlayerResponse> Handle(AddPlayerRequest request, CancellationToken cancellationToken)
        {
            var player = mapper.Map<DataAccess.Entities.Player>(request);
            var command = new AddPlayerCommand()
            {
                Parameter = player
            };
            var playerFromDb = await commandExecutor.Execute(command);
            return new AddPlayerResponse()
            {
                Data = mapper.Map<PlayerDto>(playerFromDb)
            };
        }
    }
}
