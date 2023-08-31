using MediatR;
using System.ComponentModel.DataAnnotations;

namespace HandBallTournamentv2.ApplicationServices.API.Domain.Coach
{
    public class PutCoachRequest : IRequest<PutCoachResponse>
    {
        public int Id { get; set; }

        public string ? Name { get; set; }

        public string ? Surname { get; set; }

        public float Salary { get; set; }
    }
}
