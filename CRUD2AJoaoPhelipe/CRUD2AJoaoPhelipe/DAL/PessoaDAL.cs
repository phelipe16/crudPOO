using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CRUD2AJoaoPhelipe.Model;
using System.Data;

namespace CRUD2AJoaoPhelipe.DAL
{
    public class PessoaDAL : ConecxãoDAL
    {


        //Metodo para Alterar 
        public void Alterar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("UPDATE pessoa SET nome = @nome, nascimento = @nascimento, sexo = @sexo, cpf = @cpf, " +
                    "celular = @celular, endereco = @endereco, bairro = @bairro, cidade = @cidade, estado = @estado, cep = @cep WHERE id = @id", conexao);

                comando.Parameters.AddWithValue("@id", pessoa.Id);
                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@nascimento", DateTime.Parse(pessoa.Nascimento).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                comando.Parameters.AddWithValue("@celular", pessoa.Celular);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);
                comando.Parameters.AddWithValue("@cep", pessoa.Cep);

                comando.ExecuteNonQuery();

            }
            catch (Exception erro)
            {

                throw erro ;
            }
            finally
            {
                FecharConexao(); 
            }


        }



        //Metodo para Salvar 
        public void Salvar(Pessoa pessoa)
        {
            try
            {
                AbrirConexao();
                comando = new MySqlCommand("INSERT INTO pessoa (nome, nascimento, sexo, cpf, celular, endereco, bairro, cidade, estado, cep) " +
                    "VALUES (@nome,@nascimento, @sexo, @cpf, @celular, @endereco, @bairro, @cidade, @estado, @cep)", conexao);

                comando.Parameters.AddWithValue("@nome", pessoa.Nome);
                comando.Parameters.AddWithValue("@nascimento", DateTime.Parse(pessoa.Nascimento).ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@sexo", pessoa.Sexo);
                comando.Parameters.AddWithValue("@cpf", pessoa.Cpf);
                comando.Parameters.AddWithValue("@celular", pessoa.Celular);
                comando.Parameters.AddWithValue("@endereco", pessoa.Endereco);
                comando.Parameters.AddWithValue("@bairro", pessoa.Bairro);
                comando.Parameters.AddWithValue("@cidade", pessoa.Cidade);
                comando.Parameters.AddWithValue("@estado", pessoa.Estado);
                comando.Parameters.AddWithValue("@cep", pessoa.Cep);

                comando.ExecuteNonQuery();

            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }


        }

        MySqlCommand comando = null;
        //Metodo para listar
        public DataTable Listar()
        {
            try
            {
                AbrirConexao();
                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter();

                comando = new MySqlCommand("SELECT * FROM pessoa ORDER BY nome", conexao);
                da.SelectCommand = comando;
                da.Fill(dt);
                return dt;
            }
            catch(Exception erro)
            {
                throw erro;
            }
            finally
            {
                FecharConexao();
            }

        }
    }
}
