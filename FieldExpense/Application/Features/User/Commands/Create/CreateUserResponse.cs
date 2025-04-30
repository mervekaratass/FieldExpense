namespace Application.Features.User.Commands.Create
{
    public class CreateUserResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string IBAN { get; set; }
        public string RoleName { get; set; }
    }
}
