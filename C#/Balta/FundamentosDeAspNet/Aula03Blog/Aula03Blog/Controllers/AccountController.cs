using Aula03Blog.Data;
using Aula03Blog.Extensions;
using Aula03Blog.Models;
using Aula03Blog.Services;
using Aula03Blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Aula03Blog.Controllers {
    [ApiController]
    public class AccountController : ControllerBase {
        [HttpPost("v1/accounts")]
        public async Task<IActionResult> Post(
            [FromBody] RegisterViewModel model,
            [FromServices] EmailService emailService,
            [FromServices] BlogDataContext context) {
            if (!ModelState.IsValid) {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }

            var user = new User {
                Name = model.Name,
                Email = model.Email,
                PasswordHash = model.Password,
                Slug = model.Email.Replace("@", "-").Replace(".", "-")
            };

            // var password = PasswordGenerator.Generate(25, true, true); //biblioteca open source que gera uma senha forte
            user.PasswordHash = PasswordHasher.Hash(model.Password); // a biblioteca tambem encripta a senha posso usar tanto a variavel criada na linha acima como
                                                                     // fazer o usuario digitar, colocando as regras no RegisterViewModel.cs

            try {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                emailService.Send(
                    user.Name,
                    user.Email,
                    "Bem vindo ao Blog!",
                    $"Sua senha é <strong>{model.Password}</strong>");
                
                return Ok(new ResultViewModel<dynamic>(new {
                    user = user.Email, model.Password
                }));
            }
            catch (DbUpdateException e) {
                return StatusCode(400, new ResultViewModel<string>("05X99 - Este E-mail já esta cadastrado"));
            }
            catch (Exception e) {
                return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
            }
        }

        //[Authorize(Roles = "user")] // obriga o uso do token de autenticação
        //[AllowAnonymous] // permite que o método não precise de token de autenticação caso eu use a tag [Authorize] na classe inteira
        [HttpPost("v1/accounts/login")]
        public async Task<IActionResult> Login(
            [FromBody] LoginViewModel model,
            [FromServices] TokenService tokenService,
            [FromServices] BlogDataContext context) {
            if (!ModelState.IsValid) {
                return BadRequest(new ResultViewModel<string>(ModelState.GetErrors()));
            }

            var user = await context
                .Users
                .AsNoTracking()
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Email == model.Email);

            if (user == null) {
                return StatusCode(401, new ResultViewModel<string>("Usuario ou senha Inválidos"));
            }

            if (!PasswordHasher.Verify(user.PasswordHash, model.Password)) {
                return StatusCode(401, new ResultViewModel<string>("Usuário ou senha Inválidos"));
            }

            try {
                var token = tokenService.GenerateToken(user);
                return Ok(new ResultViewModel<string>(token, []));
            }
            catch (Exception e) {
                return StatusCode(500, new ResultViewModel<string>("05X04 - Falha interna no servidor"));
            }
            
        }
    }
}