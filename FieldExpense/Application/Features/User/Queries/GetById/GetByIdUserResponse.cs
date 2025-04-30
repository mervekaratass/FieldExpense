namespace Application.Features.User.Queries.GetById
{
    public class GetByIdUserResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Iban { get; set; }
        public string Role { get; set; } 
      
    }
}
