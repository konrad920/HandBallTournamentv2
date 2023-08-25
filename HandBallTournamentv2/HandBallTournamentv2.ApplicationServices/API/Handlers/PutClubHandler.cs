using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Club;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers
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
            var clubToEdit = await this.queryExecutor.Execute(query);
            var command = new PutClubCommand() { Parameter = clubToEdit, NameOfClub = request.NameOfClub, NameOfStadium = request.NameOfStadium };
            var editedClub = await this.commandExecutor.Execute(command);
            var response = new PutClubResponse
            {
                Data = this.mapper.Map<DTO_Club>(editedClub)
            };
            return response;
        }
    }
}
