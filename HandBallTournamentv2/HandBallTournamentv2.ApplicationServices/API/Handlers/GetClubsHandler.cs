using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using HandBallTournamentv2.DataAccess.Entities;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers
{
    public class GetClubsHandler : IRequestHandler<GetClubsRequest, GetClubsResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetClubsHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetClubsResponse> Handle(GetClubsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetClubsQuery();
            var clubs = await this.queryExecutor.Execute(query);
            var mappedClubs = this.mapper.Map<List<Domain.Models.DTO_Club>>(clubs);
            var response = new GetClubsResponse()
            {
                Data = mappedClubs
            };

            return response;
        }
    }
}
