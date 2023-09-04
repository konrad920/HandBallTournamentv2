using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Club;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.DELETE;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Club
{
    public class DeleteClubHandler : IRequestHandler<DeleteClubByIdRequest, DeleteClubByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteClubHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }
        public async Task<DeleteClubByIdResponse> Handle(DeleteClubByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetClubQuery() { ClubId = request.Id };
            var clubToDelete = await queryExecutor.Execute(query);
            var command = new DeleteClubCommand() { Parameter = clubToDelete };
            var deletedClub = await commandExecutor.Execute(command);
            var response = new DeleteClubByIdResponse
            {
                Data = mapper.Map<ClubDto>(deletedClub)
            };
            return response;
        }
    }
}
