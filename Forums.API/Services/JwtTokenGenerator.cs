using Forums.API.Entities;

namespace Forums.API.Services;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly string _secret;
    private readonly string _issuer;
    private readonly string _audience;

    public JwtTokenGenerator(IConfiguration configuration)//appsetting.son წვდება IConfiguration-ი
    {
        _secret = configuration.GetValue<string>("JwtSettings:Secret");
        _issuer = configuration.GetValue<string>("JwtSettings:Issuer");
        _audience = configuration.GetValue<string>("JwtSettings:Audience");
    }

    public string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles)
    {
        throw new NotImplementedException();
    }
}