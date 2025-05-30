using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GranShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProdutosController(AppDbContext db)
        {
            _db = db;
        }

        // GET: api/produtos
        [HttpGet]
        public IActionResult Get()
        {
            var produtos = _db.Produtos
                              .Include(p => p.Categoria)
                              .ToList();
            return Ok(produtos);
        }

        // GET: api/produtos/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _db.Produtos
                             .Include(p => p.Categoria)
                             .FirstOrDefault(p => p.Id == id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // POST: api/produtos
        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Produto informado com problemas");

            _db.Produtos.Add(produto);
            _db.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        // PUT: api/produtos/{id}
        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid || id != produto.Id)
                return BadRequest("Produto informado com problemas");

            _db.Produtos.Update(produto);
            _db.SaveChanges();

            return NoContent();
        }

        // DELETE: api/produtos/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _db.Produtos.Find(id);
            if (produto == null)
                return NotFound();

            _db.Produtos.Remove(produto);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
