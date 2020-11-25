using MySql.Data.MySqlClient;
using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Areas.ADM.Models
{
    public class Mesa
    {
        public conexaoDB db = new conexaoDB();

        [Display(Name = "Id")]
        public int id { get; set; }

        /* Métodos */

        public void InsertMesa(Mesa mesa)
        {
            string strQuery = string.Format("insert into Mesa(id) " +
                                         "values ({0});", mesa.id);

            using (db = new conexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Mesa> SelectMesa()
        {
            string StrQuery = "select * from Mesa;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaMesa = new List<Mesa>();

            while (myReader.Read())
            {
                var objMesa = new Mesa()
                {
                    id = int.Parse(myReader["id"].ToString())
                };
                ListaMesa.Add(objMesa);
            }
            myReader.Close();
            return ListaMesa;
        }

        public void DeletMesa(Mesa mesa)
        {
            string StrQuery = string.Format("delete from Mesa where id = '{0}';", mesa.id);
            db.ExecutaComando(StrQuery);
        }

        /* Mudar a localização da mesa no mapa 
         
        public void UpdateMesa(Mesa mesa)
        {
            string StrQuery = "";
            StrQuery += "update Mesa set ";
            StrQuery += string.Format("posicao = {0},", mesa.posicao);
            StrQuery += string.Format("where id = {0};", mesa.id);

            db.ExecutaComando(StrQuery);
        }*/

        public Mesa SelectIdMesa(Mesa mesa)
        {
            string StrQuery = string.Format("select * from Mesa where id = {0};", mesa.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var objMesa = new Mesa();

            while (myReader.Read())
            {
                id = int.Parse(myReader["id"].ToString());
            }
            myReader.Close();
            return objMesa;
        }
    }
}