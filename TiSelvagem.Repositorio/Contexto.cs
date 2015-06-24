using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace TiSelvagem.Repositorio
{
    public class Contexto:IDisposable
    {
        private readonly SqlConnection _con;
        

        public Contexto()
        {
            _con = new SqlConnection(ConfigurationManager.ConnectionStrings["TISelvagemConfig"].ConnectionString);
            _con.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var comando = new SqlCommand()
            {
                CommandText = strQuery,
                CommandType = CommandType.Text,
                Connection = _con
            };
            comando.ExecuteNonQuery();
        }

        public SqlDataReader ExecutaComandoComRetorno(string strQuery)
        {
            var cmdComando = new SqlCommand(strQuery, _con);
            return cmdComando.ExecuteReader();
        }
        public void Dispose()
        {
            if(_con.State == ConnectionState.Open)
                _con.Close();
        }
    }
}
