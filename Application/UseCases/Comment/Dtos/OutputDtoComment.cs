namespace Application.UseCases.Comment.Dtos
{
    public class OutputDtoComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int Score { get; set; }
        public string Image { get; set; }
        public int Difficulty { get; set; }
        public int IdUser { get; set; }
        public int IdRide { get; set; }
    }
}