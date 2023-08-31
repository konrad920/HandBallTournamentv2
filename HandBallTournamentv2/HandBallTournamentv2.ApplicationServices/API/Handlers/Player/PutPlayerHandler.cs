using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.ApplicationServices.API.Domain.Player;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.PUT;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Player
{
    public class PutPlayerHandler : IRequestHandler <PutPlayerRequest, PutPlayerResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;
        private readonly ICommandExecutor commandExecutor;

        public PutPlayerHandler(IMapper mapper, IQueryExecutor queryExecutor, ICommandExecutor commandExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
            this.commandExecutor = commandExecutor;
        }

        public async Task<PutPlayerResponse> Handle(PutPlayerRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerQuery() { PlayerId = request.Id };
            var playerToEdit = await queryExecutor.Execute(query);
            var command = new PutPlayerCommand() 
            { 
                Parameter = playerToEdit,
                Name = request.Name,
                Position = request.Position,
                Surname = request.Surname,
                Salary = request.Salary,
                YearOfBirth = request.YearOfBirth 
            };
            var editedPlayer = await commandExecutor.Execute(command);
            var response = new PutPlayerResponse()
            {
                Data = mapper.Map<DTO_Player>(editedPlayer)
            };
            return response;
        }
    }
}
