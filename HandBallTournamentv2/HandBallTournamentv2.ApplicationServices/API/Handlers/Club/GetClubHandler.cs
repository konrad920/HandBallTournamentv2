using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain;
using HandBallTournamentv2.ApplicationServices.API.Domain.Club;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.ApplicationServices.API.ErrorHandling;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Queries.BYID;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers.Club
{
    public class GetClubHandler : IRequestHandler<GetClubByIdRequest, GetClubByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetClubHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetClubByIdResponse> Handle(GetClubByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetClubQuery()
            {
                ClubId = request.Id
            };
            var club = await queryExecutor.Execute(query);
            if (club == null)
            {
                return new GetClubByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var clubFromDb = mapper.Map<ClubDto>(club);
            var response = new GetClubByIdResponse()
            {
                Data = clubFromDb
            };
            return response;
        }
    }
}
