using Aula03Blog.Data;
using Aula03Blog.Models;

namespace Aula03Blog.Services;

public class CategoryServices {
    //essa classe foi criada para que eu consiga armazenar em cache a lista de categorias, olha o get list do category controller

    private readonly BlogDataContext _context;
    
    public CategoryServices(BlogDataContext context) {
        _context = context;
    }
    public List<Category> GetCategories(BlogDataContext context) {
        return context.Categories.ToList();
    }
}