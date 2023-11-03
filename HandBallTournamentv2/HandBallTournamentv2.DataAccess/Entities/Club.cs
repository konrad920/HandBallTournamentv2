using System.ComponentModel.DataAnnotations;

namespace HandBallTournamentv2.DataAccess.Entities
{
    public class Club : EntityBase
    {
        public List<Match> Matches { get; set; }

        public List<Player> Players { get; set; }

        public Coach Coach { get; set; }

        [Required]
        [MaxLength(250)]
        public string NameOfClub { get; set; }

        public string NameOfStadium { get; set; }

        public float SumOfSalary {
            set {
                var playerSalary = Players.Select(x => x.Salary).Sum();
            } 
        }
    }
}
