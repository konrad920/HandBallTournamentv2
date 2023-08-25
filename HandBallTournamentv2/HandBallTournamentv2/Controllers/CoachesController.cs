//using HandBallTournamentv2.AplicationServices.API.Domain.Club;
//using HandBallTournamentv2.AplicationServices.API.Domain.Coach;
//using HandBallTournamentv2.AplicationServices.API.Domain.Models;
//using HandBallTournamentv2.DataAccess.CQRS.Queries;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace HandBallTournament.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class CoachesController : ControllerBase
//    {
//        private readonly IMediator mediator;

//        public CoachesController(IMediator mediator)
//        {
//            this.mediator = mediator;
//        }

//        [HttpGet]
//        [Route("All")]
//        public async Task<IActionResult> GetAllCoaches([FromQuery] GetCoachesRequest request)
//        {
//            var response = await this.mediator.Send(request);
//            return this.Ok(response);
//        }

//        [HttpGet]
//        [Route("{coachId}")]
//        public async Task<IActionResult> GetClubById([FromRoute] int coachId)
//        {
//            var request = new GetCoachByIdRequest()
//            {
//                Id = coachId
//            };
//            var respone = await this.mediator.Send(request);
//            return this.Ok(respone);
//        }

//        [HttpPost]
//        [Route("")]
//        public async Task<IActionResult> AddCoach([FromBody] AddCoachRequest request)
//        {
//            var response = await this.mediator.Send(request);
//            return this.Ok(response);
//        }

//    }
//}
