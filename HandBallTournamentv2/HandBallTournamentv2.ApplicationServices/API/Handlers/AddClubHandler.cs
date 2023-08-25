using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers
{
    public class AddClubHandler : IRequestHandler<AddClubRequest, AddClubResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;

        public AddClubHandler(IMapper mapper, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
        }

        public async Task<AddClubResponse> Handle(AddClubRequest request, CancellationToken cancellationToken)
        {
            var club = this.mapper.Map<DataAccess.Entities.Club>(request);
            var command = new AddClubCommand() { Parameter = club};
            var clubFromDb = await this.commandExecutor.Execute(command);
            return new AddClubResponse()
            {
                Data = this.mapper.Map<DTO_Club>(clubFromDb)
            };

        }
    }
}
