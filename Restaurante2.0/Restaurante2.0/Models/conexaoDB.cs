using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Models
{
    public class conexaoDB : IDisposable
    {
        private readonly MySqlConnection conexao;

        public conexaoDB()
        {
            conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexao.Open();
        }

        public void ExecutaComando(string StrQuer)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuer,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader RetornaRegistro(string StrQuer)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuer,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            return vComando.ExecuteReader();
        }

        public string RetornaDado(string StrQuer)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuer,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            return vComando.ExecuteScalar().ToString();
        }

        public void Dispose()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();

        }
    }
}