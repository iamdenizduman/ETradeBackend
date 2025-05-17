using MediatR;

namespace AuthService.Application.Features.Users.LoginUser
{
    public class LoginUserRequest : IRequest<LoginUserResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
