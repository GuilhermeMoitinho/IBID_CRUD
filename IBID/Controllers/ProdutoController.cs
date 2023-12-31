using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBID.DataContext;
using IBID.Models;
using Microsoft.AspNetCore.Mvc;

namespace IBID.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var ListaDeProdutos = _context.Produtos.ToList();
            return View(ListaDeProdutos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        
        public IActionResult Editar(int id)
        {
            var IDProduto = _context.Produtos.Find(id);

            if(IDProduto == null)
                    return NotFound();

            return View(IDProduto);
        }

        public IActionResult Deletar(int id)
        {
            var IDProduto = _context.Produtos.Find(id);

            if(IDProduto == null)
                    return NotFound();

            return View(IDProduto);
        }

        public IActionResult Detalhes(int id)
        {
            var IDProduto = _context.Produtos.Find(id);

            if(IDProduto == null)
                    return NotFound();

            return View(IDProduto);
        }
        
        [HttpPost]
        public IActionResult Criar(ProdutoModel model)
        {
            model.DataDeCadastro.ToString();
            try
            {
                if(model == null || model.DataDeCadastro > DateTime.Now || !ModelState.IsValid)
                {  
                    return View();
                }

                

                _context.Produtos.Add(model);
                _context.SaveChanges();

                TempData["MensagemSucesso"] = "Criação realizada com sucesso!";

                return RedirectToAction(nameof(Index));

            }catch(Exception x)
            {
                ViewData["error"] = "Ocorreu um erro ao criar o produto.";
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Editar(ProdutoModel model)
        {

            var ProdutoBanco = _context.Produtos.Find(model.Id);

            if(model.Id == null || model.Id == 0 || !ModelState.IsValid)
            {
                return View();
            }

            ProdutoBanco.Nome = model.Nome;
            ProdutoBanco.Preco = model.Preco;
            ProdutoBanco.DataDeCadastro = model.DataDeCadastro;

            _context.Produtos.Update(ProdutoBanco);
            _context.SaveChanges();

            TempData["MensagemSucesso"] = "Edição realizada com sucesso!";


            return RedirectToAction(nameof(Index));

        }

        [HttpPost]
        public IActionResult Deletar(ProdutoModel model){

            if(model.Id == null || model.Id == 0)
            {
                return View();
            }

            var ProdutoBanco = _context.Produtos.Find(model.Id);

            _context.Produtos.Remove(ProdutoBanco);
            _context.SaveChanges();

            TempData["MensagemSucesso"] = "Remoção realizada com sucesso!";


            return RedirectToAction(nameof(Index));
        }


        }  
    }
