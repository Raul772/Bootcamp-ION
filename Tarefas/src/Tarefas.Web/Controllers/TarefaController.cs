using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        public List<TarefaViewModel> listaDeTarefas { get; set; }

        private readonly ITarefaDAO _tarefaDAO;

        private readonly IMapper _mapper;

        public TarefaController(TarefaDAO tarefaDAO, IMapper mapper)
        {
            _tarefaDAO = tarefaDAO;
            _mapper = mapper;
        }
        

        public IActionResult Index()
        {            
            var listaDeTarefasDTO = _tarefaDAO.Consultar();

            var listaDeTarefas = new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDeTarefasDTO)
            {
                listaDeTarefas.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));
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

            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);

            _tarefaDAO.Criar(tarefaDTO);

            return View();
        }

        public IActionResult Details(int id)
        {   
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);
            
            return View(tarefa);
        }

        public IActionResult Delete(int id)
        {
            _tarefaDAO.Excluir(id);

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefa)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);

            _tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("index");
        }

//      não é necessário a decoração abaixo pq ela é o padrão
        [HttpGet]
        public IActionResult Update(int id)
        {
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            return View(tarefa);
        }
        
    }
}