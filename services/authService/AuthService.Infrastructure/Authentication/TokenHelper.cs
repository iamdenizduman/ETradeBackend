using AuthService.Application.Authentication.Interfaces;
using AuthService.Application.Models.Dtos;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Authentication.Extensions.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AuthService.Infrastructure.Authentication
{
    public class TokenHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;

        public TokenHelper(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }
        public AccessToken CreateToken(User user, OperationClaimListDto operationClaimDto)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaimDto, accessTokenExpiration);           
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            
            return new AccessToken
            {
                Token = token,
                Expiration = accessTokenExpiration
            };
        }
        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, OperationClaimListDto operationClaimDto, DateTime accessTokenExpiration)
        {
            var jwt = new JwtSecurityToken
            (
                audience: tokenOptions.Audience,
                issuer: tokenOptions.Issuer,
                signingCredentials: signingCredentials,
                expires: accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaimDto)
            );
            return jwt;
        }
        private IEnumerable<Claim> SetClaims(User user, OperationClaimListDto operationClaimDto)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            if (operationClaimDto != null && operationClaimDto.Names.Count > 0)
                claims.AddRoles(operationClaimDto.Names.ToArray());
            return claims;
        }
    }
}
