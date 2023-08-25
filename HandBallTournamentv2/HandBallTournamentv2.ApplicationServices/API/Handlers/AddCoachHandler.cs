using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers
{
    public class AddCoachHandler : IRequestHandler<AddCoachRequest, AddCoachResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddCoachHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddCoachResponse> Handle(AddCoachRequest request, CancellationToken cancellationToken)
        {
            var choach = this.mapper.Map<DataAccess.Entities.Coach>(request);
            var command = new AddCoachCommand() { Parameter = choach };
            var choachFromDb = await this.commandExecutor.Execute(command);

            return new AddCoachResponse()
            {
                Data = this.mapper.Map<DTO_Coach>(choachFromDb)
            };
        }
    }
}
