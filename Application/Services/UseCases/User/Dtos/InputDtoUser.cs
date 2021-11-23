namespace Services.User.Dtos
{
    public class InputDtoUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public InputDtoUser()
        {
            
        }
    }
}