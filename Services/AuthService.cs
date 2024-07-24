using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtSettings _jwtSettings;

        public AuthService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings)
        {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<string> Authenticate(string username, string password)
        {
            var user =  await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);

            if (user == null)
            {
                return null;
            }

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _jwtSettings.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud, _jwtSettings.Audience),
            }; ;

            var token = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpireDays),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task Register(UserRegisterModel model)
        {
            var user = new User
            {
                Name = model.Name,
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };

            await _userRepository.AddUserAsync(user);
        }
    }
}
