namespace Application.Features.User.Queries.GetList
{
    public class GetListUserResponse
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
