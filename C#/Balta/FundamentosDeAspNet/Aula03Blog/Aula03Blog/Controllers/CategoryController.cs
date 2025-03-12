using Aula03Blog.Data;
using Aula03Blog.Extensions;
using Aula03Blog.Models;
using Aula03Blog.Services;
using Aula03Blog.ViewModels;
using Aula03Blog.ViewModels.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Aula03Blog.Controllers {
    [ApiController]
    [Authorize(Roles = "user")] // isso aqui obriga toda minha classe a usar o token de autenticação
    public class CategoryController : ControllerBase {
        
        [HttpGet("v1/categories")]
        public async Task<IActionResult> GetAsync(
            [FromServices] BlogDataContext context,
            [FromServices] IMemoryCache cache,
            [FromServices] CategoryServices categoryServices) {


            try {
                var categories = cache.GetOrCreate("CategoriesCache", entry => {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                    return categoryServices.GetCategories(context);
                });
                
                return Ok(new ResultViewModel<List<Category>>(categories));
            }
            catch (Exception e) {
                return StatusCode(500, new ResultViewModel<List<Category>>("05XE4 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/categories/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context) {
            try {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null) {
                    return NotFound(new ResultViewModel<Category>("Conteúdo não encontrado"));
                }

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (Exception e) {
                return StatusCode(500, new ResultViewModel<Category>("05XE5 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/categories")]
        public async Task<IActionResult> PostAsync(
            [FromBody] EditorCategoryViewModel model,
            [FromServices] BlogDataContext context) {
            if (!ModelState.IsValid) {
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
            }

            try {
                var category = new Category {
                    Name = model.Name,
                    Slug = model.Slug.ToLower(),
                };
                await context.Categories.AddAsync(category);
                await context.SaveChangesAsync();

                return Created($"v1/categories/{category.Id}", new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException e) {
                if (e.InnerException?.Message.Contains(
                        "Cannot insert duplicate key row in object 'dbo.Category' with unique index 'IX_Category_Slug'. The duplicate key value is") == true) {
                    return StatusCode(400, new ResultViewModel<Category>("Não é possivel inserir este Slug"));
                }

                return StatusCode(500, new ResultViewModel<Category>("05XE9 - Falha interna no servidor"));
            }
            catch (Exception e) {
                return StatusCode(500, new ResultViewModel<Category>($"05X10 - Não foi possivel incluir o usuario"));
            }
        }

        [HttpPut("v1/categories/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditorCategoryViewModel model,
            [FromServices] BlogDataContext context) {
            if (!ModelState.IsValid) {
                return BadRequest(new ResultViewModel<Category>(ModelState.GetErrors()));
            }

            try {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null) {
                    return NotFound(new ResultViewModel<Category>("Conteudo não encontrado"));
                }

                category.Name = model.Name;
                category.Slug = model.Slug.ToLower();

                context.Categories.Update(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException e) {
                if (e.InnerException?.Message.Contains(
                        "Cannot insert duplicate key row in object 'dbo.Category' with unique index 'IX_Category_Slug'. The duplicate key value is") == true) {
                    return StatusCode(400, new ResultViewModel<Category>("Não é possivel inserir este Slug"));
                }
                return StatusCode(500, new ResultViewModel<Category>("05X08 - Falha interna no servidor"));
            }
            catch (Exception e) {
                return StatusCode(500, new ResultViewModel<Category>($"05X11 - Não foi possivel editar o usuario"));
            }
        }

        [HttpDelete("v1/categories/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] BlogDataContext context) {
            try {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);

                if (category == null) {
                    NotFound(new ResultViewModel<Category>("Conteudo não encontrado"));
                }

                context.Categories.Remove(category);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Category>(category));
            }
            catch (DbUpdateException e) {
                return StatusCode(500, new ResultViewModel<Category>("05X07 - Falha interna no servidor"));
            }
            catch (Exception e) {
                return StatusCode(500, new ResultViewModel<Category>($"05X12 - Não foi possivel Excluir o usuario"));
            }
        }
    }
}