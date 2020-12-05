using MySql.Data.MySqlClient;
using RestauranteMexicano.Areas.ADM.Models;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.Vendas.Models
{
    public class ItensComanda
    {
        public conexaoDB db = new conexaoDB();

        /*
            Table: itenscomanda

            Columns:
            id int AI PK 
            idComanda int 
            idProduto int 
            valorUnitario decimal(6,2) 
            quantidade int 
            subtotal decimal(6,2)
             
        */

        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Id Comanda")]
        public int idComanda { get; set; }
        public virtual Comanda comanda { get; set; }

        [Display(Name = "Id Produto")]
        public int idProduto { get; set; }
        public virtual Produto produto { get; set; }

        public decimal valorUnitario { get; set; }

        public int quantidade { get; set; }

        public decimal subtotal { get; set; }

        public ItensComanda SelectIdItens(int id)
        {
            string StrQuery = string.Format("select * from itensComanda where idPedido = {0};", id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objItens = new ItensComanda();

            while (myReader.Read())
            {
                objItens.id = int.Parse(myReader["id"].ToString());
                objItens.idComanda = int.Parse(myReader["idPedido"].ToString());
                objItens.idProduto = int.Parse(myReader["idProduto"].ToString());
                objItens.valorUnitario = decimal.Parse(myReader["valorUnitario"].ToString());
                objItens.quantidade = int.Parse(myReader["quantidade"].ToString());
                objItens.subtotal = decimal.Parse(myReader["subtotal"].ToString());
            }
            myReader.Close();
            return objItens;
        }

        public void InsertItensComanda(ItensComanda itens)
        {

            string comando = string.Format("select valor from Produto where id = {0};", itens.idProduto);
            itens.valorUnitario = decimal.Parse(db.RetornaDado(comando));

            string valorUnitario = itens.valorUnitario.ToString();
            valorUnitario = valorUnitario.Replace(",", ".");

            itens.subtotal = itens.valorUnitario * itens.quantidade;
            string subtotal = itens.subtotal.ToString();
            subtotal = subtotal.Replace(",", ".");



            string strQuery = string.Format("insert into itensComanda(id, idComanda, idProduto, valorUnitario, quantidade, subtotal) " +
                                         "values ({0},{1},{2},{3},{4},{5});", itens.id, itens.idComanda, itens.idProduto, valorUnitario, itens.quantidade, subtotal);

            db.ExecutaComando(strQuery);
        }

        public void Atualizar(ItensComanda itens)
        {
            string subtotal = itens.subtotal.ToString();
            subtotal = subtotal.Replace(",", ".");

            string update = "";
            update += "update Comanda set ";
            update += string.Format("total = total + {0} ", subtotal);
            update += string.Format("where id = {0};", itens.idComanda);

            db.ExecutaComando(update);
        }

        public List<ItensComanda> SelectItensComanda()
        {
            string StrQuery = "select * from itensComanda;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaItensComanda = new List<ItensComanda>();

            while (myReader.Read())
            {
                var objItensComanda = new ItensComanda()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    idComanda = int.Parse(myReader["idComanda"].ToString()),
                    idProduto = int.Parse(myReader["idProduto"].ToString()),
                    valorUnitario = decimal.Parse(myReader["valorUnitario"].ToString()),
                    quantidade = int.Parse(myReader["quantidade"].ToString()),
                    subtotal = decimal.Parse(myReader["subtotal"].ToString()),
                };
                ListaItensComanda.Add(objItensComanda);
            }
            myReader.Close();
            return ListaItensComanda;
        }
    }
}