using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Match;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.ADD;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Match
{
    public class AddMatchHandler : IRequestHandler<AddMatchRequest, AddMatchResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddMatchHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }
        public async Task<AddMatchResponse> Handle(AddMatchRequest request, CancellationToken cancellationToken)
        {
            var match = mapper.Map<DataAccess.Entities.Match>(request);
            var command = new AddMatchCommand() { Parameter = match };
            var matchFromDb = await commandExecutor.Execute(command);
            return new AddMatchResponse()
            {
                Data = mapper.Map<DTO_Match>(matchFromDb)
            };
        }
    }
}
