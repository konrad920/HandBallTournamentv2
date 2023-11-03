
namespace HandBallTournamentv2.ApplicationServices.API.Domain.Models
{
    public class ClubDto
    {
        public int Id { get; set; }

        public string ClubName { get; set; }

        public List<string> Players { get; set; }

        public float CostOfSalary { get; set; }
    }
}
