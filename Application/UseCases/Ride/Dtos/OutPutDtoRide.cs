namespace Application.UseCases.Ride.Dtos
{
    public class OutPutDtoRide
    {
        public int Id { get; set; }
        public string NameRide { get; set; }
        public string Place { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public int Difficulty { get; set; }
        public string Schedule { get; set; }
        public string Photo { get; set; }
        public int Score { get; set; }
        public int IdUser { get; set; }
    }
}