﻿namespace HandBallTournamentv2.ApplicationServices.API.Domain
{
    public abstract class ResponseBase<T> : ErrorResponseBase
    {
        public T Data { get; set; }
    }
}
