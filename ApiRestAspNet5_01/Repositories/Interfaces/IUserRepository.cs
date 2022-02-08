using ApiRestAspNet5_01.Data.VO;
using ApiRestAspNet5_01.Models;

namespace ApiRestAspNet5_01.Repositories.Interfaces
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string userName);
        bool RevokeToken(string userName);
        User RefreshUserInfo(User user);
    }
}
