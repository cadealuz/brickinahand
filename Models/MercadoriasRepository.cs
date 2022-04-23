using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;

namespace Brick_in_a_Hand.Models
{
    public class MercadoriasRepository
    {
        private const String DadosConexao = "Database=Brick_in_a_Hand; Data Source=localhost; user Id=root;";

        public void MercadoriasExcluir(Mercadorias pac)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Delete from Mercadorias where Id = @Id";

            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            Comando.Parameters.AddWithValue("@Id", pac.Id);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void MercadoriasAlterar(Mercadorias pac)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Update Mercadorias set Nome=@Nome, Referencia=@Referencia, Preco=@Preco, Tipo=@Tipo, Descricao=@Descricao where Id = @Id";

            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            Comando.Parameters.AddWithValue("@Id", pac.Id);
            Comando.Parameters.AddWithValue("@Nome", pac.Nome);
            Comando.Parameters.AddWithValue("@Referencia", pac.Referencia);
            Comando.Parameters.AddWithValue("@Preco", pac.Preco);
            Comando.Parameters.AddWithValue("@Tipo", pac.Tipo);
            Comando.Parameters.AddWithValue("@Descricao", pac.Descricao);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public void MercadoriasInserir(Mercadorias pac)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Insert into Mercadorias (Nome, Referencia, Preco, Tipo, Descricao) Values (@Nome, @Referencia, @Preco, @Tipo, @Descricao)";

            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

           Comando.Parameters.AddWithValue("@Nome", pac.Nome);
            Comando.Parameters.AddWithValue("@Referencia", pac.Referencia);
            Comando.Parameters.AddWithValue("@Preco", pac.Preco);
            Comando.Parameters.AddWithValue("@Tipo", pac.Tipo);
            Comando.Parameters.AddWithValue("@Descricao", pac.Descricao);

            Comando.ExecuteNonQuery();

            Conexao.Close();
        }

        public List<Mercadorias> MercadoriasListar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Select * From Mercadorias";

            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Mercadorias> Lista = new List<Mercadorias>();

            while(Reader.Read())
            {
                Mercadorias MercadoriasEncontrado = new Mercadorias();

                MercadoriasEncontrado.Id = Reader.GetInt32("Id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    MercadoriasEncontrado.Nome = Reader.GetString("Nome");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Referencia")))    
                MercadoriasEncontrado.Referencia = Reader.GetInt32("Referencia");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Preco")))
                MercadoriasEncontrado.Preco = Reader.GetDouble("Preco");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Tipo")))
                MercadoriasEncontrado.Tipo = Reader.GetString("Tipo");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Descricao")))
                MercadoriasEncontrado.Descricao = Reader.GetString("Descricao");

                Lista.Add(MercadoriasEncontrado);
            }
            Conexao.Close();
            return Lista;

        }

        public Mercadorias BuscarPorId(int Id)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "Select * From Mercadorias where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query,Conexao);

            Comando.Parameters.AddWithValue("@Id", Id);
            
            MySqlDataReader Reader = Comando.ExecuteReader();

            Mercadorias MercadoriasEncontrado = new Mercadorias();
            
            if(Reader.Read())
            {
                MercadoriasEncontrado.Id = Reader.GetInt32("Id");

                if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    MercadoriasEncontrado.Nome = Reader.GetString("Nome");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Referencia")))    
                MercadoriasEncontrado.Referencia = Reader.GetInt32("Referencia");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Preco")))
                MercadoriasEncontrado.Preco = Reader.GetDouble("Preco");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Tipo")))
                MercadoriasEncontrado.Tipo = Reader.GetString("Tipo");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("Descricao")))
                MercadoriasEncontrado.Descricao = Reader.GetString("Descricao");

            }
            Conexao.Close();
            return MercadoriasEncontrado;
        }

    }
}