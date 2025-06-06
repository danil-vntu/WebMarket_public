using WebMarket.DTOs;

namespace WebMarket.Services
{
    public interface IAuthService
    {
        public ResultDto Register(RegisterDto registerDto);
        public ResultDto Login(LoginDto loginDto);
        public bool IsAdmin();
        UserDto? GetCurrentUser(int userId);
    }
}
