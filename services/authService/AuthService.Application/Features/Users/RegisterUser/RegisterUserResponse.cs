using Shared.Entity.Abstracts;

namespace AuthService.Application.Features.Users.RegisterUser
{
    public class RegisterUserResponse : BaseResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
