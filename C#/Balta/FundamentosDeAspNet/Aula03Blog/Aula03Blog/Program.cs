using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;
using Aula03Blog.Data;
using Aula03Blog.Services;
using Aula03Blog.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
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
            
            app.UseResponseCompression(); // serve para comprimir as Apis deixando a request mais leve
            app.UseAuthentication(); // Força meu sistema a usar autenticação
            app.UseAuthorization(); // Força meu sistama a usar autorização
            app.UseStaticFiles(); // Serve para o servidor conseguir renderizar arquivos estaticos (fotos, txt, arquivo JS etc).
            app.MapControllers(); // mapeia meus controlers dentro da pasta Controllers
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
                builder.Services.AddMemoryCache();
                builder.Services.AddResponseCompression(option => {
                    //option.Providers.Add<BrotliCompressionProvider>();
                    option.EnableForHttps = true;
                    option.Providers.Add<GzipCompressionProvider>();
                    //option.Providers.Add<CustomCompressionProvider>();
                });
                builder.Services.Configure<GzipCompressionProviderOptions>(options => {
                    options.Level = CompressionLevel.Optimal;
                });
                builder
                    .Services
                    .AddControllers()
                    .ConfigureApiBehaviorOptions(options => {
                        options.SuppressModelStateInvalidFilter = true;
                    }) // desabilitando a validação automatica da resposta da API (model state) 
                    .AddJsonOptions(x => {
                        x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles; // isso faz que ele ignore ciclos subsequentes, por exemplo no
                                                                                                  // postcontroller eu faço um join onde um post tem muitas categorias e uma
                                                                                                  // categoria tem muitos posts entrando em um loop infinito
                                                                                                  
                        x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault; // quando o objeto tem valor padrão como por exemplo null ele
                                                                                                                 // não vai renderizar o objeto na tela.
                    }); 
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
                builder.Services.AddTransient<CategoryServices>();
            }
        }
    }
}
