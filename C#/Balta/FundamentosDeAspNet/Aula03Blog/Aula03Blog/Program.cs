using System.Text;
using Aula03Blog.Data;
using Aula03Blog.Services;
using Aula03Blog.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Aula03Blog {
    public class Program {
        public static void Main(string[] args) {
            
            var builder = WebApplication.CreateBuilder(args);
            ConfigureAuthentication(builder);
            ConfigureMvc(builder);
            ConfigureServices(builder);
            
            var app = builder.Build();
            LoadConfiguration(app);
            
            app.Use(async (context, next) =>
            {
                await next();

                if (context.Response.StatusCode == 401)
                {
                    context.Response.ContentType = "application/json";
                    var result = new ResultViewModel<string>("Faça login para continuar.");
                    await context.Response.WriteAsJsonAsync(result);
                }
            }); // esse trecho de código serve para caso o cliente não esteja usando o
                // token a API retorno a mensagem no padrão definitido em resultViewModel
            
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            
            
            // criei esses métodos para não bagunçar a classe program
            void LoadConfiguration(WebApplication app) {
                Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey");
                Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKeyName");
                Configuration.ApiKey = app.Configuration.GetValue<string>("ApiKey");

                var smtp = new Configuration.SmtpConfiguration();
                app.Configuration.GetSection("Smtp").Bind(smtp);
                Configuration.Smtp = smtp;
            }
            void ConfigureAuthentication(WebApplicationBuilder builder) {
                // esse bloco configura a autenticação JWT para que as APIs validem tokens JWT em requisições.
                var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);

                builder.Services.AddAuthentication(x => {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(x => {
                    x.TokenValidationParameters = new TokenValidationParameters {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            }
            void ConfigureMvc(WebApplicationBuilder builder) {
                builder.Services
                    .AddControllers()
                    .ConfigureApiBehaviorOptions(options => {
                        options.SuppressModelStateInvalidFilter = true;
                    }); // desabilitando a validação automatica da resposta da API (model state) 
            }
            void ConfigureServices(WebApplicationBuilder builder) {
                builder.Services.AddDbContext<BlogDataContext>(); // adicionando o banco de dados no aspnet, a vantagem é que eu
                                                                  // nao preciso utilizar o using e abrir uma conexão com o banco
                                                                  // todas as vezes que eu precisar
            
                //usar sempre um desses 3 
                builder.Services.AddTransient<TokenService>(); // se dentro da requisição ele passar por varios métodos ele irá instanciar o tokenservices em todos os metódos que passar
                //builder.Services.AddScoped<TokenService>(); // igual ao de cima, mas vai durar por requisição, ou seja, irá instanciar uma vez e reutilizar para todos os metodos que passar
                //builder.Services.AddSingleton<TokenService>(); // dura até o encerramento do APP, cuidado ao usar esse
                
                builder.Services.AddTransient<EmailService>();
            }
        }
    }
}
