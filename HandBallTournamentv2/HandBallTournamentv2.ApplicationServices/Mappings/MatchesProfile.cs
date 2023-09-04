using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.Mappings
{
    public class MatchesProfile :Profile
    {
        public MatchesProfile()
        {
            this.CreateMap<DataAccess.Entities.Match, MatchDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
                .ForMember(x => x.HostClubId, y => y.MapFrom(z => z.HostClubId))
                .ForMember(x => x.QuestClubId, y => y.MapFrom(z => z.QuestClubId))
                .ForMember(x => x.HostScore, y => y.MapFrom(z => z.HostScore))
                .ForMember(x => x.QuestScore, y => y.MapFrom(z => z.QuestScore))
                .ForMember(x => x.Audience, y => y.MapFrom(z => z.Audience))
                .ForMember(x => x.TicketCost, y => y.MapFrom(z => z.TicketCost));
        }
    }
}
