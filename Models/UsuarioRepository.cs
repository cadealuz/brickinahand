using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Brick_in_a_Hand.Models
{
    public class UsuarioRepository
    {
        private const String DadosConexao = "Database=Brick_in_a_Hand; Data Source=localhost; user Id=root;";

        public void TestarConexao(){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            Console.WriteLine("Banco de dados funcionando");
            Conexao.Close();
        }
        public void Excluir(Usuario usu){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Delete from Usuario where Id = @Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id",usu.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void Alterar(Usuario usu)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Update Usuario set Nome=@Nome, Email=@Email, Senha=@Senha where Id = @Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id",usu.Id);
            Comando.Parameters.AddWithValue("@Nome",usu.Nome);
            Comando.Parameters.AddWithValue("@Email",usu.Email);
            Comando.Parameters.AddWithValue("@Senha",usu.Senha);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void Inserir(Usuario usu)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Insert into Usuario(Nome, Email, Senha) Values (@Nome, @Email, @Senha)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome",usu.Nome);
            Comando.Parameters.AddWithValue("@Email",usu.Email);
            Comando.Parameters.AddWithValue("@Senha",usu.Senha);
           
            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<Usuario> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Select * From Usuario";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuario> Lista = new List<Usuario>();

            while(Reader.Read())
            {
                Usuario UsuarioEncontrado = new Usuario();

                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))   
                    UsuarioEncontrado.Email = Reader.GetString("Email");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))    
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
                    
                Lista.Add(UsuarioEncontrado);
            }

            Conexao.Close();

            return Lista;
        }

        public Usuario BuscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Select * From Usuario where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = new Usuario();

            if(Reader.Read())
            {
                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))   
                    UsuarioEncontrado.Email = Reader.GetString("Email");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))    
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
                    
            }

            Conexao.Close();
            return UsuarioEncontrado;
        }

        public Usuario ValidarLogin(Usuario usu)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Select * From Usuario where Email=@Email AND Senha=@Senha";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Email", usu.Email);
            Comando.Parameters.AddWithValue("@Senha", usu.Senha);

            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario UsuarioEncontrado = null;

            if(Reader.Read())
            {
                UsuarioEncontrado = new Usuario();
                
                UsuarioEncontrado.Id = Reader.GetInt32("Id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    UsuarioEncontrado.Nome = Reader.GetString("Nome");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))   
                    UsuarioEncontrado.Email = Reader.GetString("Email");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))    
                    UsuarioEncontrado.Senha = Reader.GetString("Senha");
                    
            }

            Conexao.Close();
            return UsuarioEncontrado;
        }
        
    }
}