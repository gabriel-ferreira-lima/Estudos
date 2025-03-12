using Aula03Blog.Data;
using Aula03Blog.Models;

namespace Aula03Blog.Services;

public class CategoryServices {
    
    private readonly BlogDataContext _context;
    
    public CategoryServices(BlogDataContext context) {
        _context = context;
    }
    public List<Category> GetCategories(BlogDataContext context) {
        return context.Categories.ToList();
    }
}