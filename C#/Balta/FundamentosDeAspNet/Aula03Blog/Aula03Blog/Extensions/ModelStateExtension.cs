using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Aula03Blog.Extensions {
    public static class ModelStateExtension {
        
        // essa classe adiciona um metódo GetErrors() a classe modelStateDictionary do aspnet
        public static List<string> GetErrors(this ModelStateDictionary modelState) {

            var result = new List<string>();
            foreach (var item in modelState.Values) {

                foreach (var error in item.Errors) {
                    result.Add(error.ErrorMessage);
                }
            }
            return result;
        }
    }
}
