using Dapper;
using System;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Tarefas.DTO;

namespace Tarefas.DAO
{
    
    public class UsuarioDAO : IUsuarioDAO
    {
        private string DataSourceFile => Environment.CurrentDirectory + "AppTarefasDB.sqlite";
        public SQLiteConnection Connection => new SQLiteConnection("DataSource=" + DataSourceFile);

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