using System.ComponentModel.DataAnnotations;

namespace HandBallTournamentv2.DataAccess.Entities
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}
