using Aula03Blog.Data;
using Aula03Blog.Models;
using Aula03Blog.ViewModels;
using Aula03Blog.ViewModels.Posts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula03Blog.Controllers;

[ApiController]
public class PostController : ControllerBase {
    [HttpGet("v1/posts")]
    public async Task<IActionResult> GetPosts(
        [FromServices] BlogDataContext context,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25) {
        try {
            var count = await context.Posts.CountAsync();
            var posts = await context
                .Posts
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Author)
                .Select(x => new ListPostsViewModel {
                    Id = x.Id,
                    Title = x.Title,
                    Slug = x.Slug,
                    LastUpdateDate = x.LastUpdateDate,
                    Category = x.Category.Name,
                    Author = $"{x.Author.Name} ({x.Author.Email})",
                })
                .Skip(page * pageSize)
                .Take(pageSize)
                .OrderByDescending(x => x.LastUpdateDate)
                .ToListAsync();
            return Ok(new ResultViewModel<dynamic>(new {
                posts,
                total = count,
                page,
                pageSize,
            }));
        }
        catch (Exception e) {
            return StatusCode(500, new ResultViewModel<List<Post>>("05X04 - Falha interna do servidor"));
        }
    }

    [HttpGet("v1/posts/{id:int}")]
    public async Task<IActionResult> GetPostsById(
        [FromServices] BlogDataContext context,
        [FromRoute] int id) {
        try {
            var posts = await context
                .Posts
                .AsNoTracking()
                .Include(x => x.Category)
                .Include(x => x.Author)
                .ThenInclude(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (posts == null) {
                return NotFound(new ResultViewModel<string>("Conteudo não encontrado"));
            }

            return Ok(new ResultViewModel<Post>(posts));
        }
        catch (Exception e) {
            return StatusCode(500, new ResultViewModel<List<Post>>("05X04 - Falha interna do servidor"));
        }
    }

    [HttpGet("v1/posts/Category/{category}")]
    public async Task<IActionResult> GetByCategoryAsync(
        [FromRoute] string category,
        [FromServices] BlogDataContext context,
        [FromQuery] int page = 0,
        [FromQuery] int pageSize = 25) {
        
        try {
            var count = await context.Posts.Where(x => x.Category.Slug == category).CountAsync();
            var posts = await context
                .Posts
                .AsNoTracking()
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Where(x => x.Category.Slug == category)
                .Select(x => new ListPostsViewModel {
                    Id = x.Id,
                    Title = x.Title,
                    Slug = x.Slug,
                    LastUpdateDate = x.LastUpdateDate,
                    Category = x.Category.Name,
                    Author = $"{x.Author.Name} ({x.Author.Email})",
                })
                .ToListAsync();

            return Ok(new ResultViewModel<dynamic>(new {
                posts,
                total = count,
                page,
                pageSize,
            }));
        }
        catch (Exception e) {
            return StatusCode(500, new ResultViewModel<Post>("Ocorreu um erro interno no servidor"));
        }
    }
}