namespace HandBallTournamentv2.ApplicationServices.API.Domain
{
    public abstract class ResponseBase<T>
    {
        public T Data { get; set; }
    }
}
