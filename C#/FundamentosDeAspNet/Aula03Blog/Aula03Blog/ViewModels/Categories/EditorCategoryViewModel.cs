using System.ComponentModel.DataAnnotations;

namespace Aula03Blog.ViewModels.Categories {
    public class EditorCategoryViewModel{

        [Required (ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "este campo deve conter entre 3 e 4 caracteres")]
        public string Name { get; set; }

        [Required (ErrorMessage = "O slug é obrigatório")]
        //[Unique]
        public string Slug { get; set; }
    }
}
