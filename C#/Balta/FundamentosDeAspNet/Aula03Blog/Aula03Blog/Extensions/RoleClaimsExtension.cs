using System.Security.Claims;
using Aula03Blog.Models;

namespace Aula03Blog.Extensions;

public static class RoleClaimsExtension {
    public static IEnumerable<Claim> GetClains(this User user) {
        var result = new List<Claim> {
            new Claim(ClaimTypes.Name, user.Email)
        };
        result.AddRange(
            user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Slug))
        );
        return result;
    }
}