using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aula01.Model {

    [Table("Category")]
    internal class Category {

        [Key] // indica que o campo ID será a chave primaria da tabela 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // isso diz que o campo ID é auto incremental 
        public int Id { get; set; }

        [Required] // mesma coisa que is not null no banco
        [MinLength(3)] // quantidade minima de caracteres que o varchar vai ter no banco
        [MaxLength(80)] // quantidade maxima de caracteres que o varchar vai ter no banco
        [Column("Name", TypeName = "NVARCHAR")] // Mapeando que esse campo deve ser um NVARCHAR e não qualquer outro tipo de cmapo de texto
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")] 
        public string Slug { get; set; }
    }
}
