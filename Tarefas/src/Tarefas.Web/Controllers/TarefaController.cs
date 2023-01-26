using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        public List<Tarefa> listaDeTarefas { get; set; }

        public TarefaController()
        {
            listaDeTarefas = new List<Tarefa>()
            {
                new Tarefa() { Id = 1, Titulo = "Escovar os dentes" },
                new Tarefa() { Id = 2, Titulo = "Arrumar a cama" },
                new Tarefa() { Id = 3, Titulo = "Por o lixo para fora", Descricao = "somente às terças, quintas e sábados" }
            };
        }
        

        public IActionResult Index()
        {            
            var tarefaDAO = new TarefaDAO();
            var listaDeTarefasDTO = tarefaDAO.Consultar();

            var listaDeTarefas = new List<Tarefa>();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefas.Add( 
                    new Tarefa(){ 
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
        public IActionResult Create(Tarefa tarefa)
        {
            var tarefaDTO = new TarefaDTO 
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Criar(tarefaDTO);

            return View();
        }

        public IActionResult Details(int id)
        {   
            var tarefaDAO = new TarefaDAO();
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new Tarefa(){
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Id = tarefaDTO.Id,
                Concluida = tarefaDTO.Concluida
            };
            
            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Excluir(id);

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Update(Tarefa tarefa)
        {
            var tarefaDTO = new TarefaDTO() 
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("index");
        }

//      não é necessário a decoração abaixo pq ela é o padrão
        [HttpGet]
        public IActionResult Update(int id)
        {
            var tarefaDAO = new TarefaDAO();
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new Tarefa(){
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };

            return View(tarefa);
        }
        


    }
}