using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class TarefaViewModel
{
    public int Id { get; set; }
    
    
    [Required(ErrorMessage = "Por favor informe um Título.")]
    [MinLength(5, ErrorMessage = "Título muito curto.")]
    [DisplayName("Título")]    
    public string? Titulo { get; set; }        
    
    
    [Required(ErrorMessage = "Por favor informe uma Descrição.")]
    [MinLength(5, ErrorMessage = "Descrição muito curta.")]
    [DisplayName("Descrição")]    
    public string? Descricao { get; set; }  


    [Required(ErrorMessage = "Por favor informe um status.")]
    [DisplayName("Concluída")]
    public bool Concluida { get; set; }
}