using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Aula03Blog.Extensions;
using Aula03Blog.Models;
using Microsoft.IdentityModel.Tokens;

namespace Aula03Blog.Services;

public class TokenService {

    // Classe responsável por gerar um JWT (JSON Web Token) para autenticação de usuários.  
    // O token gerado pode ser utilizado no cabeçalho Authorization como um Bearer Token.
    public string GenerateToken(User user) {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
        var claims = user.GetClains();
        var tokenDescriptor = new SecurityTokenDescriptor {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        
        return tokenHandler.WriteToken(token);
    }

}