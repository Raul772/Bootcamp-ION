using Dapper;
using Tarefas.DTO;

namespace Tarefas.DAO
{
    
    public class UsuarioDAO : BaseDAO, IUsuarioDAO
    {
        

        public UsuarioDAO()
        {
            
        }

        public void Criar(UsuarioDTO usuario)
        {
            using (var con = Connection)
            {
                con.Open();
                con.Execute(
                    @"INSERT INTO Usuario
                    (Email, Senha, Nome, Ativo) VALUES
                    (@Email, @Senha, @Nome, @Ativo);", usuario
                );
            }
        }
    }
}