using HandBallTournamentv2.ApplicationServices.API.Domain;
using HandBallTournamentv2.ApplicationServices.API.Domain.Match;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.ApplicationServices.API.Domain.Player;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HandBallTournamentv2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchesController : ControllerBase
    {
        private readonly IMediator mediator;

        public MatchesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllMatches([FromQuery] GetMatchesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{matchId}")]
        public async Task<IActionResult> GetMatchById([FromRoute] int matchId)
        {
            var request = new GetMatchByIdRequest()
            {
                Id = matchId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddMatch([FromBody] AddMatchRequest request)
        {
            //if (!this.ModelState.IsValid)
            //{
            //    return this.BadRequest("BADREQUEST Match");
            //}
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("matchId")]
        public async Task<IActionResult> DeleteMatchById([FromQuery] int matchId)
        {
            var request = new DeleteMatchByIdRequest()
            {
                Id = matchId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("matchId")]
        public async Task<IActionResult> EditMatch([FromBody] PutMatchRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
