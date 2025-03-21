using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;
using Aula03Blog.Data;
using Aula03Blog.Services;
using Aula03Blog.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Aula03Blog {
    public class Program {
        public static void Main(string[] args) {
            
            var builder = WebApplication.CreateBuilder(args);
            LoadConfiguration(builder);
            ConfigureServices(builder);
            ConfigureMvc(builder);
            ConfigureAuthentication(builder);
            
            builder.Services.AddEndpointsApiExplorer(); // faz com que o swagger seja adicionado
            builder.Services.AddSwaggerGen(); // gera o código da interface do swagger
            
            var app = builder.Build();
            
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
            app.UseHttpsRedirection(); // ela permite fazer redirecionamento http para https
            app.UseAuthentication(); // Força meu sistema a usar autenticação
            app.UseAuthorization(); // Força meu sistama a usar autorização
            app.UseStaticFiles(); // Serve para o servidor conseguir renderizar arquivos estaticos (fotos, txt, arquivo JS, css, html e etc).
            app.MapControllers(); // mapeia meus controlers dentro da pasta Controllers
            
            // isso serve para eu alterar algumas informações apenas no ambiente de desenvolvimento
            if (app.Environment.IsDevelopment()) {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.Run();
            
            
            // criei esses métodos para não bagunçar a classe program
            void LoadConfiguration(WebApplicationBuilder builder) {
                // esse método esta pegando os valores definidos em appsettings e setando os valores dentro da classe configuration.cs
                Configuration.JwtKey = builder.Configuration.GetValue<string>("JwtKey"); // essa chave será essencial para gerar os tokens nesse
                                                                                         // caso peguei um guid Guid.NewGuid(); depois transformei
                                                                                         // ele em base64 o valor da chave esta no appSettings
                                                                                         
                
                                                                                         
                Configuration.ApiKeyName = builder.Configuration.GetValue<string>("ApiKeyName"); // criando um conceito diferente de criar uma chave além do JWT,
                                                                                                 // essa aqui não expira nunca ver na pasta attributes e na homeController
                Configuration.ApiKey = builder.Configuration.GetValue<string>("ApiKey");
                
                Configuration.ImageDirectory = builder.Configuration.GetValue<string>("ImageDirectory");

                var smtp = new Configuration.SmtpConfiguration();
                builder.Configuration.GetSection("Smtp").Bind(smtp);
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
                builder.Services.AddMemoryCache(); // olha a API getlist do category controller
                builder.Services.AddResponseCompression(option => {
                    //option.Providers.Add<BrotliCompressionProvider>();
                    option.EnableForHttps = true;
                    option.Providers.Add<GzipCompressionProvider>();
                    //option.Providers.Add<CustomCompressionProvider>();
                });
                builder.Services.Configure<GzipCompressionProviderOptions>(options => {
                    options.Level = CompressionLevel.Optimal;
                }); // isso configura que eu quero que minhas APIs sejam zipadas, para deixar a requisição mais leve
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
                
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                builder.Services.AddDbContext<BlogDataContext>(options => {
                    options.UseSqlServer(connectionString);
                }); // adicionando o banco de dados no aspnet, a vantagem é que eu
                                                                  // nao preciso utilizar o using e abrir uma conexão com o banco
                                                                  // todas as vezes que eu precisar
            
                //usar sempre um desses 3 
                builder.Services.AddTransient<TokenService>(); // se dentro da requisição ele passar por varios métodos ele irá instanciar o tokenservices em todos os metódos que passar
                //builder.Services.AddScoped<TokenService>(); // igual ao de cima, mas vai durar por requisição, ou seja, irá instanciar uma vez e reutilizar para todos os metodos que passar
                //builder.Services.AddSingleton<TokenService>(); // dura até o encerramento do APP, cuidado ao usar esse
                
                builder.Services.AddTransient<EmailService>();
                builder.Services.AddTransient<CategoryCacheServices>();
            }
        }
    }
}
