using HomeWork.Models.IdentityModel;
using HomeWork.Service.Models.AuthModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HomeWork.Core.AuthServices;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly JwtSettings _jwtSettings;

    public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<LoginResponse> Login(LoginModel loginModel)
    {
        var user = await _userManager.FindByEmailAsync(loginModel.Email) ?? throw new Exception($"User with {loginModel.Email} not found.");
        var result = await _signInManager.PasswordSignInAsync(user.UserName, loginModel.Password, loginModel.RememberMe, lockoutOnFailure:false);
        if(!result.Succeeded)
        {
            throw new Exception($"Credentials for {loginModel.Email} is not valid.");
        }
        var jwtToken = await GenerateToken(user);

        return new LoginResponse
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
            Email = user.Email,
            UserName = user.UserName,
        };
    }

    private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
    {
        var userClaim = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }

        var claims = new[] {
            
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim("UserId", user.Id),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())        
        }.Union(userClaim).Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signInCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer:_jwtSettings.Issuer,
            audience:_jwtSettings.Audience,
            claims:claims,
            expires:DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials:signInCredentials
            );
    }

    public async Task<RegisterResponse> Register(RegisterModel registerModel)
    {
        var existingUserName = await _userManager.FindByNameAsync(registerModel.UserName);
        if (existingUserName != null)
        {
            throw new Exception($"Email {registerModel.UserName} already exists.");
        }

        var user = new ApplicationUser
        {
            Email = registerModel.Email,
            UserName = registerModel.UserName,
            EmailConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
        };

        var existingEmail = await _userManager.FindByEmailAsync(registerModel.Email);
        if (existingEmail == null)
        {
            var result = await _userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                return new RegisterResponse { UserId = user.Id };
            }
            throw new Exception($"{result.Errors}");
        }
        throw new Exception($"Email {registerModel.Email} already exists.");
    }
}
