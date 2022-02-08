using ApiRestAspNet5_01.Data.VO;

namespace ApiRestAspNet5_01.Services.Interfaces
{
    public interface ILoginService
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string userName);
    }
}
