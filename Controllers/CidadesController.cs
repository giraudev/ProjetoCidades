using Microsoft.AspNetCore.Mvc;
using ProjetoCidades.Models;
using ProjetoCidades.Repositorio;

namespace ProjetoCidades.Controllers
{
    public class CidadesController : Controller
    {
        Cidade cidade = new Cidade();
        //criar objeto do cidadeRepositorio
        CidadeRepositorio objCidadeRep = new CidadeRepositorio();
        public IActionResult Index()
        {
            //colocar o objRep e seu metodo
            //ele vai listar as infos do banco de dados
            var lista = objCidadeRep.Listar();
            return View(lista);
        }

        public IActionResult CidadesEstados()
        {
            var lista = cidade.ListarCidades();
            return View(lista);
        }

        public IActionResult TodosDados()
        {
            var lista = cidade.ListarCidades();
            return View(lista);
        }
        
        //[HttpGet e HttpPost] é usado quando quero fazer duas ações
        //no exemplo vou visualizar e mandar os dados
        [HttpGet]//usado qndo quero visualizar e obter o dado

        public IActionResult Cadastrar()
        {
            return View();
        }

        
        [HttpPost]//usado quando quero enviar dados
        //Bind é usado quando recebemos informações
        public IActionResult Cadastrar([Bind]Cidade cidade)
        {
            objCidadeRep.Cadastrar(cidade);
            return RedirectToAction("Index");
        }

         [HttpGet]//usado qndo quero visualizar e obter o dado

        public IActionResult Editar(int id)
        {
           var dados = objCidadeRep.ListarCidades(id);
            return View(dados);
        }

        
        [HttpPost]//usado quando quero enviar dados
        //Bind é usado quando recebemos informações
        public IActionResult Editar([Bind]Cidade cidade)
        {
            objCidadeRep.Editar(cidade);
            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id){
            var dados=objCidadeRep.Excluir(id);
            return RedirectToAction("index");
        }

    }
}