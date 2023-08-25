using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Match;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;

namespace HandBallTournamentv2.ApplicationServices.Mappings
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            this.CreateMap<AddMatchRequest, DataAccess.Entities.Match>()
                .ForMember(x => x.Audience, y => y.MapFrom(z => z.MatchAudience))
                .ForMember(x => x.TicketCost, y => y.MapFrom(z => z.MatchTicketCost))
                .ForMember(x => x.HostClubId, y => y.MapFrom(z => z.MatchHostClubId))
                .ForMember(x => x.QuestClubId, y => y.MapFrom(z => z.MatchQuestClubId))
                .ForMember(x => x.HostPoints, y => y.MapFrom(z => z.MatchHostPoints))
                .ForMember(x => x.QuestPoints, y => y.MapFrom(z => z.MatchQuestPoints))
                .ForMember(x => x.HostScore, y => y.MapFrom(z => z.MatchHostScore))
                .ForMember(x => x.QuestScore, y => y.MapFrom(z => z.MatchQuestScore));

            this.CreateMap<DataAccess.Entities.Match, Match>()
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
