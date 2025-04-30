namespace Application.Features.User.Commands.Delete
{

    public class DeleteUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }       
        public string Phone { get; set; }       
        public string IBAN { get; set; }
        public string RoleName { get; set; }
     
    }

}
