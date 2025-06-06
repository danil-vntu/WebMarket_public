using WebMarket.DTOs;
using WebMarket.Models;
using WebMarket.Data;
using AutoMapper;
namespace WebMarket.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(AppDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public ResultDto Register(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);

            if (user == null)
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "Введено не вірні дані!"
                };
            }

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "Користувача з таким email вже зареєстровано!"
                };
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);

            _context.Users.Add(user);
            _context.SaveChanges();

            return new ResultDto()
            {
                Success = true,
                Message = "Реєстрація пройшла успішно!"
            };
        }

        public ResultDto Login(LoginDto loginDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == loginDto.Email.ToLower());
            if (user == null)
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "Користувача з таким email не знайдено!"
                };
            }

            if (!BCrypt.Net.BCrypt.Verify(loginDto.Password, user.PasswordHash))
            {
                return new ResultDto()
                {
                    Success = false,
                    Message = "Невірний логін, або пароль!"
                };
            }

            return new ResultDto()
            {
                Success = true,
                Message = "Вхід пройшов успішно!",
                UserId = user.Id
            };
        }

        public bool IsAdmin()
        {
            var userId = _httpContextAccessor.HttpContext?.Session?.GetInt32("UserId");
            if (userId == null) return false;

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return false;

            if (user.Role != "Admin") return false;

            return true;
        }

        public UserDto? GetCurrentUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null) return null;

            UserDto userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }
    }
}