using System.Security.Claims;
using DataLayer.Repositories;

namespace BusinessLayer.Services;

public class ClaimService
{
    private readonly UserRepository userRepository;
    private readonly RoleRepository roleRepository;

    public ClaimService(UserRepository userRepository, RoleRepository roleRepository)
    {
        this.userRepository = userRepository;
        this.roleRepository = roleRepository;
    }

    public ClaimsPrincipal? GetClaims(string email, string password)
    {
        var user = userRepository.Get(email, password);
        if (user == null)
        {
            return null;
        }

        var role = roleRepository.GetRoleByUserId(user.Id);

        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.Name ?? string.Empty),
            new("Role", role?.Name ?? string.Empty),
        };

        var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
        var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

        return claimsPrincipal;
    }
}