using AuthService.Application.Models.Dtos;
using Shared.Entity.Abstracts;

namespace AuthService.Application.Features.Users.LoginUser
{
    public class LoginUserResponse : BaseResponse
    {
        public AccessToken AccessToken { get; set; }
    }
}
