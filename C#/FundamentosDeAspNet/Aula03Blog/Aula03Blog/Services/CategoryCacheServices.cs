using Aula03Blog.Data;
using Aula03Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Aula03Blog.Services;

public class CategoryCacheServices {
    //essa classe foi criada para que eu consiga armazenar em cache a lista de categorias, olha o get list do category controller

    private readonly BlogDataContext _context;

    public CategoryCacheServices(BlogDataContext context) {
        _context = context;
    }
    public List<Category> GetCategories(BlogDataContext context) {
        return context.Categories.ToList();
    }
}