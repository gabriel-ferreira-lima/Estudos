using System.ComponentModel.DataAnnotations;

namespace Aula03Blog.ViewModels.Accounts;

public class RegisterViewModel {
    
    [Required(ErrorMessage = "O name é obrigatório")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Email é obrigatório")]
    [EmailAddress(ErrorMessage = "O Email é invalido")] // isso serve para validar se o Email é valido
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Password é obrigatório")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
        ErrorMessage = "A senha deve conter pelo menos 8 caracteres, incluindo uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")]
    public string Password { get; set; }
    
}