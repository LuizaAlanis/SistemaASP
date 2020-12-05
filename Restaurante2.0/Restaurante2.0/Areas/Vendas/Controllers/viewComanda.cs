using MySql.Data.MySqlClient;
using RestauranteMexicano.Areas.ADM.Models;
using RestauranteMexicano.Areas.Vendas.Models;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.Vendas.Controllers
{
    public class viewComanda
    {
        public conexaoDB db = new conexaoDB();

        /*
            View: viewdelivery

            Columns:
	        Comanda.id,
            Comanda.idMesa,
            Comanda.dataPedido,
            Produto.produto,
            Produto.valor,
            itensComanda.quantidade,
            itensComanda.subtotal,
            Comanda.total
        */

        public int id { get; set; }

        public int idMesa { get; set; }
        
        public DateTime dataPedido { get; set; }

        public string produto { get; set; }

        public decimal valor { get; set; }

        public int quantidade { get; set; }

        public decimal subtotal { get; set; }

        public decimal total { get; set; }

        public List<viewComanda> SelectViewComanda()
        {
            string StrQuery = "select * from viewComanda;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaviewComanda = new List<viewComanda>();

            while (myReader.Read())
            {
                var objviewComanda = new viewComanda()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    idMesa = int.Parse(myReader["idMesa"].ToString()),
                    dataPedido = DateTime.Parse(myReader["dataPedido"].ToString()),
                    produto = myReader["produto"].ToString(),
                    valor = decimal.Parse(myReader["valor"].ToString()),
                    quantidade = int.Parse(myReader["quantidade"].ToString()),
                    subtotal = decimal.Parse(myReader["subtotal"].ToString()),
                    total = decimal.Parse(myReader["total"].ToString())
                };
                ListaviewComanda.Add(objviewComanda);
            }
            myReader.Close();
            return ListaviewComanda;
        }

    }
}