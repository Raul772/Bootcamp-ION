using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        public List<TarefaViewModel> listaDeTarefas { get; set; }

        private TarefaDAO tarefaDAO {get; set;}

        public TarefaController()
        {
            tarefaDAO = new TarefaDAO();
        }
        

        public IActionResult Index()
        {            
            var listaDeTarefasDTO = tarefaDAO.Consultar();

            var listaDeTarefas = new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefas.Add( 
                    new TarefaViewModel(){ 
                        Id = tarefaDTO.Id,
                        Titulo = tarefaDTO.Titulo,
                        Descricao = tarefaDTO.Descricao,
                        Concluida = tarefaDTO.Concluida
                    });
            }
            
            return View(listaDeTarefas);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TarefaViewModel tarefa)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var tarefaDTO = new TarefaDTO 
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            tarefaDAO.Criar(tarefaDTO);

            return View();
        }

        public IActionResult Details(int id)
        {   
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel(){
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Id = tarefaDTO.Id,
                Concluida = tarefaDTO.Concluida
            };
            
            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            tarefaDAO.Excluir(id);

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefa)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var tarefaDTO = new TarefaDTO() 
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("index");
        }

//      não é necessário a decoração abaixo pq ela é o padrão
        [HttpGet]
        public IActionResult Update(int id)
        {
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel(){
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };

            return View(tarefa);
        }
        


    }
}