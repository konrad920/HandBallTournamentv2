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
    public class ClubsController : ApiControllerBase
    {
        public ClubsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("All")]
        public Task<IActionResult> GetAllClubs([FromQuery] GetClubsRequest request)
        {
            return this.HandleRequest<GetClubsRequest, GetClubsResponse>(request);
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
        }

        [HttpGet]
        [Route("{clubId}")]
        public Task<IActionResult> GetClubById([FromRoute] int clubId)
        {
            var request = new GetClubByIdRequest()
            {
                Id = clubId
            };
            return this.HandleRequest<GetClubByIdRequest, GetClubByIdResponse>(request);
            //var respone = await this.mediator.Send(request);
            //return this.Ok(respone);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddClub([FromBody] AddClubRequest request)
        {
            return this.HandleRequest<AddClubRequest, AddClubResponse>(request);
            //if (!this.ModelState.IsValid)
            //{
            //    return this.BadRequest("BADREQUEST Club");
            //}
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
        }

        [HttpDelete]
        [Route("clubId")]
        public Task<IActionResult> DeleteClubById([FromQuery] int clubId)
        {
            var request = new DeleteClubByIdRequest()
            {
                Id = clubId
            };
            return this.HandleRequest<DeleteClubByIdRequest, DeleteClubByIdResponse>(request);
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
        }

        [HttpPut]
        [Route("clubId")]
        public Task<IActionResult> EditClub([FromBody] PutClubRequest request)
        {
            return this.HandleRequest<PutClubRequest, PutClubResponse>(request);
            //var response = await this.mediator.Send(request);
            //return this.Ok(response);
        }
    }
}
