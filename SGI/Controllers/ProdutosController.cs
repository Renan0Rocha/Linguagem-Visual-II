using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGI.Data;
using SGI.Models;

namespace SGI.Controllers;

public class ProdutosController : Controller
{
    private readonly SGIContext _context;

    public ProdutosController(SGIContext context)
    {
        _context = context;
    }

    // RF01 - Listar Produtos: equivalente a SELECT ... ORDER BY nome ASC
    public async Task<IActionResult> Index()
    {
        var produtos = await _context.Produtos
            .OrderBy(p => p.Nome)
            .ToListAsync();

        return View(produtos);
    }

    // RF05 - Detalhes: equivalente a SELECT * FROM produtos WHERE id = @id
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

        if (produto == null) return NotFound();

        return View(produto);
    }

    // RF02 - Cadastrar Produto (GET)
    public IActionResult Create()
    {
        return View();
    }

    // RF02 - Cadastrar Produto (POST): equivalente a INSERT INTO produtos (...)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Nome,Preco,Quantidade")] Produto produto)
    {
        if (!ModelState.IsValid) return View(produto);

        _context.Produtos.Add(produto);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    // RF03 - Editar Produto (GET): equivalente a SELECT * FROM produtos WHERE id = @id
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var produto = await _context.Produtos.FindAsync(id);

        if (produto == null) return NotFound();

        return View(produto);
    }

    // RF03 - Editar Produto (POST): equivalente a UPDATE produtos SET ... WHERE id = @id
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Preco,Quantidade")] Produto produto)
    {
        if (id != produto.Id) return NotFound();

        if (!ModelState.IsValid) return View(produto);

        try
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await _context.Produtos.AnyAsync(p => p.Id == produto.Id))
                return NotFound();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    // RF04 - Excluir Produto (GET): confirmação visual
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

        if (produto == null) return NotFound();

        return View(produto);
    }

    // RF04 - Excluir Produto (POST): equivalente a DELETE FROM produtos WHERE id = @id
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var produto = await _context.Produtos.FindAsync(id);

        if (produto != null)
        {
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }
}
