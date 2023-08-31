using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Coach;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.DELETE;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Coach
{
    public class DeleteCoachHandler : IRequestHandler<DeleteCoachByIdRequest, DeleteCoachByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public DeleteCoachHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteCoachByIdResponse> Handle(DeleteCoachByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachQuery() { CoachId = request.Id };
            var coachToDelete = await queryExecutor.Execute(query);
            var command = new DeleteCoachCommand() { Parameter = coachToDelete };
            var deletedCoach = await commandExecutor.Execute(command);
            var response = new DeleteCoachByIdResponse
            {
                Data = mapper.Map<DTO_Coach>(deletedCoach)
            };
            return response;
        }
    }
}
