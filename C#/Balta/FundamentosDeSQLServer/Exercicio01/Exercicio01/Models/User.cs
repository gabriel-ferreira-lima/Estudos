using System.ComponentModel.DataAnnotations.Schema;
using Dapper.Contrib.Extensions;

namespace Exercicio01.Models {
    [Dapper.Contrib.Extensions.Table("[User]")] // Por padrão o Dapper sempre irá procurar no banco o nome da classo como se estivesse no plural
                      // No exemplo a baixo a classe User, será prurada como Users, porem no banco a tabela se chama User
                      // Desta forma criamos essa notação para obrigar o daper a procurar no banco da forma que eu quiser
                      // No caso removi o S
                      // Prestar atenção na importação que é feita ao chamar a classe table, ela existe em outros namespaces
                      // Desta forma prestar atenção se o using ficou como "Dapper.Contrib.Extensions", isso indica que estou chamando
                      // a classe table do namespace correto 
    internal class User {

        public User() {
            Roles = new List<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)]
        public List<Role> Roles { get; set; }
    }
}
