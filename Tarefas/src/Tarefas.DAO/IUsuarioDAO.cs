using System.Data.SQLite;
using Tarefas.DTO;

namespace Tarefas.DAO
{
    public interface IUsuarioDAO
    {
        SQLiteConnection Connection { get; }

        void Criar(UsuarioDTO usuario);
    }

}