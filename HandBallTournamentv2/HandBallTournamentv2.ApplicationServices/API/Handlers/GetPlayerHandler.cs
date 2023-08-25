﻿using AutoMapper;
using HandBallTournamentv2.ApplicationServices.API.Domain.Models;
using HandBallTournamentv2.ApplicationServices.API.Domain.Player;
using HandBallTournamentv2.DataAccess.CQRS;
using HandBallTournamentv2.DataAccess.CQRS.Queries;
using MediatR;

namespace HandBallTournamentv2.ApplicationServices.API.Handlers
{
    public class GetPlayerHandler : IRequestHandler<GetPlayerByIdRequest, GetPlayerByIdResponse>
    {
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public GetPlayerHandler(IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }
        public async Task<GetPlayerByIdResponse> Handle(GetPlayerByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetPlayerQuery()
            {
                PlayerId = request.Id
            };
            var player = await this.queryExecutor.Execute(query);
            var playerFromDb = this.mapper.Map<DTO_Player>(player);
            var response = new GetPlayerByIdResponse()
            {
                Data = playerFromDb
            };
            return response;
        }
    }
}
