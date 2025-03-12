using System.ComponentModel.DataAnnotations;

namespace Aula03Blog.ViewModels.Accounts;

public class UploadImageViewModel {
    
    [Required(ErrorMessage = "Imagem inválida")]
    public string Base64Image { get; set; }
}