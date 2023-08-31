using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Coach
{
    public class DeleteCoachByIdRequest : IRequest<DeleteCoachByIdResponse>
    {
        public int Id { get; set; }
    }
}
