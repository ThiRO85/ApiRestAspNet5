using ApiRestAspNet5_01.Authentication;
using ApiRestAspNet5_01.Configurations;
using ApiRestAspNet5_01.Data.VO;
using ApiRestAspNet5_01.Repositories.Interfaces;
using ApiRestAspNet5_01.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApiRestAspNet5_01.Services.Implementations
{
    public class LoginServiceImplementation : ILoginService
    {
        private const string DATA_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenCofiguration _configuration;
        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginServiceImplementation(TokenCofiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidateCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            if (user == null) return null;

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var accessToken = _tokenService.GeneratedAccessToken(claims);
            var refreshToken = _tokenService.GeneratedRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddDays(_configuration.Minutes);

            return new TokenVO(
                true, 
                createDate.ToString(DATA_FORMAT),
                expirationDate.ToString(DATA_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public TokenVO ValidateCredentials(TokenVO token)
        {
            var accessToken = token.AccessToken;
            var refreshToken = token.RefreshToken;

            var principal = _tokenService.GetPrincipalFromExpiratedToken(accessToken);

            var userName = principal.Identity.Name;

            var user = _repository.ValidateCredentials(userName);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;
            }

            accessToken = _tokenService.GeneratedAccessToken(principal.Claims);
            refreshToken = _tokenService.GeneratedRefreshToken();

            user.RefreshToken = refreshToken;

            _repository.RefreshUserInfo(user);

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddDays(_configuration.Minutes);

            return new TokenVO(
                true,
                createDate.ToString(DATA_FORMAT),
                expirationDate.ToString(DATA_FORMAT),
                accessToken,
                refreshToken
                );
        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}
