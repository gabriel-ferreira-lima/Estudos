using Aula03Blog.Data;

namespace Aula03Blog {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                .AddControllers()
                .ConfigureApiBehaviorOptions(options => {
                    options.SuppressModelStateInvalidFilter = true;
                }); // desabilitando a validação automatica da resposta da API 

            builder.Services.AddDbContext<BlogDataContext>();

            var app = builder.Build();
            app.MapControllers();

            app.Run();
        }
    }
}
