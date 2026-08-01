using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Aula03Blog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
        [JsonIgnore] // isso aqui faz com que mesmo eu fazendo um select na api e traga todas as
                     // informações do usuario, na api não terá retorno da propriedade abaixo no caso o PasswordHash
        public string PasswordHash { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
        public string Bio { get; set; }

        public IList<Post> Posts { get; set; }
        public IList<Role> Roles { get; set; }
    }
}