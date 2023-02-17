namespace MagicVilla_VillaAPI.Repository;

using Data;
using Models;
using Models.DTO;
using AutoMapper;
using System.Text;
using IRepository;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity;

public class UserRepository : IUserRepository
{
    private string secretKey;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _db;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public UserRepository(ApplicationDbContext db, RoleManager<IdentityRole> roleManager,
        UserManager<ApplicationUser> userManager, IConfiguration configuration, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _roleManager = roleManager;
        _userManager = userManager;
        secretKey = configuration.GetValue<string>("ApiSettings:Secret");
    }

    public bool IsUniqueUser(string username)
    {
        var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName == username);

        if (user == null)
        {
            return true;
        }

        return false;
    }

    public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
    {
        var user = _db.ApplicationUsers.FirstOrDefault(u =>
            u.UserName.ToLower() == loginRequestDTO.UserName.ToLower());

        bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);

        if (user == null || !isValid)
        {
            return new LoginResponseDTO
            {
                Token = "",
                User = null
            };
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);
        var roles = await _userManager.GetRolesAsync(user);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        LoginResponseDTO loginResponseDto = new()
        {
            Token = tokenHandler.WriteToken(token),
            User = _mapper.Map<UserDTO>(user)
        };

        return loginResponseDto;
    }

    public async Task<UserDTO> Register(RegistrationRequestDTO registrationRequestDTO)
    {
        ApplicationUser user = new()
        {
            UserName = registrationRequestDTO.UserName,
            Name = registrationRequestDTO.Name,
            Email = registrationRequestDTO.UserName,
            NormalizedEmail = registrationRequestDTO.UserName.ToUpper()
        };

        try
        {
            var result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);

            if (result.Succeeded)
            {
                if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                {
                    await _roleManager.CreateAsync(new IdentityRole("admin"));
                    await _roleManager.CreateAsync(new IdentityRole("customer"));
                }

                await _userManager.AddToRoleAsync(user, "admin");
                var userToReturn = _db.ApplicationUsers
                    .FirstOrDefault(u => u.UserName == registrationRequestDTO.UserName);

                return _mapper.Map<UserDTO>(userToReturn);
            }
        }
        catch (Exception e)
        {
            throw new InvalidOperationException();
        }

        return new UserDTO();
    }
}