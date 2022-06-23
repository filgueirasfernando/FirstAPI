using FirstAPI.Data;
using FirstAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstAPI.Controller
{
  [ApiController]
  [Route("v1/produtos")]
  public class ProdutoController : ControllerBase
  {
    [HttpGet]
    [Route("")]
    public async Task <ActionResult<List<Produto>>> Get ([FromServices] DataContext context)
    {
      return await context.Produtos.Include(x => x.Categoria).ToListAsync();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Produto>> Get([FromServices] DataContext context, int id)
    {
      return await context.Produtos.Include(x => x.Categoria)
                                   .AsNoTracking()
                                   .FirstOrDefaultAsync(x => x.Id == id);
    }

    [HttpGet]
    [Route("categoria/{id:int}")]
    public async Task<ActionResult<List<Produto>>> GetProdutoPorCategoria([FromServices] DataContext context, int id)
    {
      return await context.Produtos.Include(x => x.Categoria)
                                   .AsNoTracking()
                                   .Include(x => x.Categoria)
                                   .Where(x => x.CategoriaId == id)
                                   .ToListAsync();
    }

    [HttpPost]
    [Route("")]
    public async Task<ActionResult<Produto>> Post ([FromServices] DataContext context, [FromBody] Produto model)
    {
      if (ModelState.IsValid)
      {
        context.Produtos.Add(model);
        await context.SaveChangesAsync();
        return model;
      }
      else return BadRequest(ModelState);
    }
  }
}
