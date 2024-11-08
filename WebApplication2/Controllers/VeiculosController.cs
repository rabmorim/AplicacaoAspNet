using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class VeiculosController : Controller
    {
        // criando uma leitura do banco de dados
        // readonly quer dizer somento leitura
        private readonly AppDBContext _context;
        public VeiculosController(AppDBContext context)
        {
            _context = context;
        }
        // async e Task é para criação de metodos assincronos e não atrapalhar o desenvolvimento da aplicação
        public async Task<IActionResult> Index()
        {
            // Pegando os dados da tabela veiculos e transformando em uma lista
            var dados = await _context.Veiculos.ToListAsync();
            return View(dados);
        }
        //Não precisaria colocar o método HttpGet,pois como default ele vem ele de padrão.
        //E esse método está falando para exibir o formulário para o usuário ou seja um get
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                _context.Veiculos.Add(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(veiculo);
        }

        //Método Get do Edit Veiculo

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            {
                if (id == null)
                    return NotFound();


                var dados = await _context.Veiculos.FindAsync(id);

                if (dados == null)
                    return NotFound();

                return View(dados);
            }
        }

        //Método Post do Edit Veiculo
        [HttpPost]

        public async Task<IActionResult> Edit(int? id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(veiculo);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(veiculo);
        }
        //Método Get Details do veiculo
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        // Método Get Delete
        public async Task<IActionResult> Delete (int? id) 
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Veiculos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Veiculos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}

