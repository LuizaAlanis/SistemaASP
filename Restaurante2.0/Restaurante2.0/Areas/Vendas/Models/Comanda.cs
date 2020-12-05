using MySql.Data.MySqlClient;
using RestauranteMexicano.Areas.ADM.Models;
using RestauranteMexicano.Areas.RH.Models;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.Vendas.Models
{
    public class Comanda
    {
        public conexaoDB db = new conexaoDB();

        /*
            Table: comanda
        
            Columns:
            id int PK
            dataPedido date
            total decimal (6,2) 
            idMesa int
            idFuncionario int
         */

        // Atributos

        [Display(Name = "Id")]
        [Key]
        public int id { get; set; }

        [Display(Name = "Data")]
        public DateTime data { get; set; }

        [Display(Name = "Total")]
        public decimal total { get; set; }

        [Display(Name = "Mesa")]
        public int idMesa { get; set; }
        public virtual Mesa mesa { get; set; }

        [Display(Name = "Funcionario")]
        public int idFuncionario { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public ICollection<ItensComanda> ItensComanda { get; set; }

        // Métodos

        public void InsertComanda(Comanda comanda)
        {
            string strQuery = string.Format("insert into Comanda(id, dataPedido, total, idMesa, idFuncionario) " +
                                         "values ({0},'{1}',{2},{3},{4});", comanda.id, comanda.data.ToString("yyyy-MM-dd"), comanda.total, comanda.idMesa, comanda.idFuncionario);

            db.ExecutaComando(strQuery);
        }

        public List<Comanda> SelectComanda()
        {
            string StrQuery = "select * from Comanda;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaComanda = new List<Comanda>();

            while (myReader.Read())
            {
                var objComanda = new Comanda()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    data = DateTime.Parse(myReader["dataPedido"].ToString()),
                    total = decimal.Parse(myReader["total"].ToString()),
                    idMesa = int.Parse(myReader["idMesa"].ToString()),
                    idFuncionario = int.Parse(myReader["idFuncionario"].ToString())
                };
                ListaComanda.Add(objComanda);
            }
            myReader.Close();
            return ListaComanda;
        }

        public void DeleteComanda(Comanda comanda)
        {
            string StrQuery = string.Format("delete from Comanda where id = {0};", comanda.id);
            db.ExecutaComando(StrQuery);
        }

        public Comanda SelectIdComanda(Comanda comanda)
        {
            string StrQuery = string.Format("select * from Comanda where id = {0};", comanda.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objComanda = new Comanda();

            while (myReader.Read())
            {
                objComanda.id = int.Parse(myReader["id"].ToString());
                objComanda.data = DateTime.Parse(myReader["dataPedido"].ToString());
                objComanda.total = decimal.Parse(myReader["total"].ToString());
                objComanda.idMesa = int.Parse(myReader["idMesa"].ToString());
                objComanda.idFuncionario = int.Parse(myReader["idFuncionario"].ToString());
            }
            myReader.Close();
            return objComanda;
        }

        public void UpdateComanda(Comanda comanda)
        {
            string StrQuery = "";
            StrQuery += "update Comanda set ";
            StrQuery += string.Format("dataComanda = '{0}', ", comanda.data.ToString("yyyy-MM-dd"));
            StrQuery += string.Format("total = {0}, ", comanda.total);
            StrQuery += string.Format("idMesa = {0}, ", comanda.idMesa);
            StrQuery += string.Format("idFuncionario = {0} ", comanda.idFuncionario);
            StrQuery += string.Format("where id = {0};", comanda.id);

            db.ExecutaComando(StrQuery);
        }
    }
}