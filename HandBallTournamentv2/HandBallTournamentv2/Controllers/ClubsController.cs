using HandBallTournamentv2.ApplicationServices.API.Domain.Club;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.DataAccess;
using HandBallTournamentv2.DataAccess.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HandBallTournamentv2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClubsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ClubsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAllClubs([FromQuery] GetClubsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{clubId}")]
        public async Task<IActionResult> GetClubById([FromRoute] int clubId)
        {
            var request = new GetClubByIdRequest()
            {
                Id = clubId
            };
            var respone = await this.mediator.Send(request);
            return this.Ok(respone);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddClub([FromBody] AddClubRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpDelete]
        [Route("clubId")]
        public async Task<IActionResult> DeleteClubById([FromQuery] int clubId)
        {
            var request = new DeleteClubByIdRequest()
            {
                Id = clubId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("clubId")]
        public async Task<IActionResult> EditClub([FromBody] PutClubRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
