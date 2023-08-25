using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Coach
{
    public class GetCoachByIdRequest : IRequest<GetCoachByIdResponse>
    {
        public int Id { get; set; }
    }
}
