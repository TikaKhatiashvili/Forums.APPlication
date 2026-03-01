using Forums.API.Data;
using Forums.API.Entities;
using Forums.API.Models.DTO.Auth;
using MapsterMapper;
using Microsoft.AspNetCore.Identity;

namespace Forums.API.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string _adminRoleName = "Admin";
    private const string _authoRoleName = "Author";

    public AuthService(
        ApplicationDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IJwtTokenGenerator jwtTokenGenerator,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtTokenGenerator = jwtTokenGenerator;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task Register(RegistrationRequestDto registrationRequestDto)
    {
        throw new NotImplementedException();
    }

    public Task RegisterAdmin(RegistrationRequestDto registrationRequestDto)
    {
        throw new NotImplementedException();
    }
}
