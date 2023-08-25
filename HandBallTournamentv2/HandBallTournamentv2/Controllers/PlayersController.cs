//using HandBallTournamentv2.AplicationServices.API.Domain.Club;
//using HandBallTournamentv2.AplicationServices.API.Domain.Models;
//using HandBallTournamentv2.AplicationServices.API.Domain.Player;
//using HandBallTournamentv2.AplicationServices.API.Handlers;
//using HandBallTournamentv2.DataAccess;
//using HandBallTournamentv2.DataAccess.Entities;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace HandBallTournament.Controllers
//{
//    [ApiController]
//    [Route("[controller]")]
//    public class PlayersController : ControllerBase
//    {
//        private readonly IMediator mediator;

//        public PlayersController(IMediator mediator)
//        {
//            this.mediator = mediator;
//        }

//        [HttpGet]
//        [Route("All")]
//        public async Task<IActionResult> GetAllPlayers([FromQuery] GetPlayersRequest request)
//        {
//            var response = await this.mediator.Send(request);
//            return this.Ok(response);
//        }

//        [HttpGet]
//        [Route("{playerId}")]
//        public async Task<IActionResult> GetClubById([FromRoute] int playerId)
//        {
//            var request = new GetPlayerByIdRequest()
//            {
//                Id = playerId
//            };
//            var respone = await this.mediator.Send(request);
//            return this.Ok(respone);
//        }

//        [HttpPost]
//        [Route("")]
//        public async Task<IActionResult> AddPlayer([FromBody] AddPlayerRequest request)
//        {
//            var response = await this.mediator.Send(request);
//            return this.Ok(response);
//        }
//    }
//}
