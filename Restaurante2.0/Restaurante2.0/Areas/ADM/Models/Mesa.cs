using MySql.Data.MySqlClient;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.ADM.Models
{
    public class Mesa
    {
        public conexaoDB db = new conexaoDB();

        /* TABELA
        
            id int primary key
        */

        // Atributos

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        // Métodos

        public void InsertMesa(Mesa mesa)
        {
            string StrQuery = string.Format("select * from Mesa where id = {0};", id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            myReader.Close();

            if (!myReader.HasRows) //não há registro.
            {
                string strQuery = string.Format("insert into Mesa(id) " +
                    "values ({0});", mesa.id);
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

        public void DeleteMesa(int id)
        {
            string StrQuery = string.Format("delete from Mesa where id = {0};", id);
            db.ExecutaComando(StrQuery);
        }
    }
}