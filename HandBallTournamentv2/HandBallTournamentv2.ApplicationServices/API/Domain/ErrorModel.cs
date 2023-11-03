namespace HandBallTournamentv2.ApplicationServices.API.Domain
{
    public class ErrorModel
    {
        public ErrorModel(string error)
        {
            this.Error = error;
        }

        public string Error { get; set; }
    }
}