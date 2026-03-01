using Forums.API.Entities;

namespace Forums.API.Services;

public interface IJwtTokenGenerator
{
    string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
}
