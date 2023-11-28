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
        }
    }
}
