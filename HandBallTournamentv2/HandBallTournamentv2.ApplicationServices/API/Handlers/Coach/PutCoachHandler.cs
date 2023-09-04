using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Coach;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Commands.PUT;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Coach
{
    public class PutCoachHandler : IRequestHandler<PutCoachRequest, PutCoachResponse>
    {
        private readonly IMapper mapper;
        private readonly ICommandExecutor commandExecutor;
        private readonly IQueryExecutor queryExecutor;

        public PutCoachHandler(IMapper mapper, ICommandExecutor commandExecutor, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.commandExecutor = commandExecutor;
            this.queryExecutor = queryExecutor;
        }

        public async Task<PutCoachResponse> Handle(PutCoachRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachQuery() { CoachId = request.Id };
            var coachToEdit = await queryExecutor.Execute(query);
            var command = new PutCoachCommand() { Parameter = coachToEdit, Name = request.Name, Surname = request.Surname, Salary = request.Salary };
            var editedCoach = await commandExecutor.Execute(command);
            var response = new PutCoachResponse()
            {
                Data = mapper.Map<CoachDto>(editedCoach),
            };
            return response;
        }
    }
}
