using Dapper.Contrib.Extensions;

namespace Exercicio01.Models {
    [Table ("[Tag]")]
    internal class Tag {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
    }
}
