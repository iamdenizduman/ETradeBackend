using AuthService.Application.Features.Users.LoginUser;
using AuthService.Application.Features.Users.RegisterUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
