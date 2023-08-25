//using HandBallTournamentv2.AplicationServices.API.Domain;
//using HandBallTournamentv2.AplicationServices.API.Domain.Match;
//using HandBallTournamentv2.AplicationServices.API.Domain.Models;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace HandBallTournament.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class MatchesController : ControllerBase
//    {
//        private readonly IMediator mediator;

//        public MatchesController(IMediator mediator)
//        {
//            this.mediator = mediator;
//        }

//        [HttpGet]
//        [Route("All")]
//        public async Task<IActionResult> GetAllMatches([FromQuery] GetMatchesRequest request)
//        {
//            var response = await this.mediator.Send(request);
//            return this.Ok(response);
//        }

//        [HttpGet]
//        [Route("{matchId}")]
//        public async Task<IActionResult> GetMatchById([FromRoute] int matchId)
//        {
//            var request = new GetMatchByIdRequest()
//            {
//                Id = matchId
//            };
//            var response = await this.mediator.Send(request);
//            return this.Ok(response);
//        }

//        [HttpPost]
//        [Route("")]
//        public async Task<IActionResult> AddMatch([FromBody] AddMatchRequest request)
//        {
//            var response = await this.mediator.Send(request);
//            return this.Ok(response);
//        }
//    }
//}
