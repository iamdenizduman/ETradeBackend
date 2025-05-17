using AuthService.Application.Models.Dtos;
using AuthService.Domain.Entities;

namespace AuthService.Application.Authentication.Interfaces
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, OperationClaimListDto operationClaimDto);
    }
}
