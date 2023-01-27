using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class Tarefa
{
    public int Id { get; set; }
    
    [MinLength(5, ErrorMessage = "Título muito curto.")]
    [Required(ErrorMessage = "Por favor informe um Título.")]
    [DisplayName("Título")]    
    public string? Titulo { get; set; }        
    
    [MinLength(5, ErrorMessage = "Descrição muito curta.")]
    [Required(ErrorMessage = "Por favor informe uma Descrição.")]
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; }  


    [Required(ErrorMessage = "Por favor informe um status.")]
    [DisplayName("Concluída")]
    public bool Concluida { get; set; }
}