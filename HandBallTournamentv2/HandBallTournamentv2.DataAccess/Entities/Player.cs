using System.ComponentModel.DataAnnotations;

namespace HandBallTournamentv2.DataAccess.Entities
{
    public class Player : EntityBase
    {
        public int ClubId { get; set; }

        public Club Club { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(150)]
        public string Position { get; set; }

        public int YearOfBirth { get; set; }

        public float Salary { get; set; }
    }
}
