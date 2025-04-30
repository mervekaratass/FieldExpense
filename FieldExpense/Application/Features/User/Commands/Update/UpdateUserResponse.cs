namespace Application.Features.User.Commands.Update
{
    public class UpdateUserResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string IBAN { get; set; } = null!;
        public string RoleName { get; set; } = null!;
    }
}
