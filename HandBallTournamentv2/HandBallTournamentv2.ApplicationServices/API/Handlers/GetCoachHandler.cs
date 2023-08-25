using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Coach;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers
{
    public class GetCoachHandler : IRequestHandler<GetCoachByIdRequest, GetCoachByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetCoachHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetCoachByIdResponse> Handle(GetCoachByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCoachQuery() 
            { 
                CoachId = request.Id 
            };
            var coach = await this.queryExecutor.Execute(query);
            var coachFromDb = this.mapper.Map<Coach>(coach);
            var response = new GetCoachByIdResponse()
            {
                Data = coachFromDb
            };
            return response;
        }
    }
}
