using AuthService.Application.Authentication.Interfaces;
using AuthService.Application.Models.Dtos;
using AuthService.Application.Repository.Interfaces;
using MediatR;

namespace AuthService.Application.Features.Users.LoginUser
{
    public class LoginUserHandler : IRequestHandler<LoginUserRequest, LoginUserResponse>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IUserOperationClaimReadRepository _userOperationClaimReadRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IHashingHelper _hashingHelper;

        public LoginUserHandler(IUserReadRepository userReadRepository, IUserOperationClaimReadRepository userOperationClaimReadRepository, ITokenHelper tokenHelper, IHashingHelper hashingHelper)
        {
            _userReadRepository = userReadRepository;
            _userOperationClaimReadRepository = userOperationClaimReadRepository;
            _tokenHelper = tokenHelper;
            _hashingHelper = hashingHelper;
        }

        public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userReadRepository.GetSingleAsync(u => u.Email == request.Email, u => u.UserOperationClaims);
            if (user == null)
                return new LoginUserResponse
                {
                    isSuccess = false,
                    text = "Kullanıcı adı veya şifre hatalı"
                };

            bool passwordCheck = _hashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt);

            if (!passwordCheck)
                return new LoginUserResponse
                {
                    isSuccess = false,
                    text = "Kullanıcı adı veya şifre hatalı"
                };

            var operationClaims = (await _userReadRepository.GetUserWithClaimsAsync(request.Email))?.UserOperationClaims.Select(u => u.OperationClaim);
            OperationClaimListDto operationClaimDtos = new OperationClaimListDto
            {
                Names = operationClaims?.Select(u => u.Name)?.ToList()
            };

            var accessToken = _tokenHelper.CreateToken(user, operationClaimDtos);

            return new LoginUserResponse
            {
                AccessToken = accessToken,
                isSuccess = true,
                text = "Giriş Başarılı"
            };
        }
    }
}
