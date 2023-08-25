using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Club;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.PUT;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Club
{
    public class PutClubHandler : IRequestHandler<PutClubRequest, PutClubResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutClubHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<PutClubResponse> Handle(PutClubRequest request, CancellationToken cancellationToken)
        {
            var query = new GetClubQuery() { ClubId = request.Id };
            var clubToEdit = await queryExecutor.Execute(query);
            var command = new PutClubCommand() { Parameter = clubToEdit, NameOfClub = request.NameOfClub, NameOfStadium = request.NameOfStadium };
            var editedClub = await commandExecutor.Execute(command);
            var response = new PutClubResponse
            {
                Data = mapper.Map<DTO_Club>(editedClub)
            };
            return response;
        }
    }
}
