using MySql.Data.MySqlClient;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.SAC.Models
{
    public class Celular
    {
        public conexaoDB db = new conexaoDB();

        /* TABELA
        
            id int AI PK 
            ddd int 
            numero int
        */

        // Atributos

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "DDD")]
        public int ddd { get; set; }

        [Display(Name = "Número")]
        public int numero { get; set; }


        public ICollection<Cliente> Cliente { get; set; }


        // Métodos

        public void InsertCelular(Celular celular)
        {
            string strQuery = string.Format("insert into Celular(id, ddd, numero) " +
                                         "values ({0},{1},{2});", celular.id, celular.ddd, celular.numero);

            db.ExecutaComando(strQuery);
        }

        public List<Celular> SelectCelular()
        {
            string StrQuery = "select * from Celular;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaCelular = new List<Celular>();

            while (myReader.Read())
            {
                var objCelular = new Celular()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    ddd = int.Parse(myReader["ddd"].ToString()),
                    numero = int.Parse(myReader["numero"].ToString())
                };
                ListaCelular.Add(objCelular);
            }
            myReader.Close();
            return ListaCelular;
        }

        public void DeleteCelular(Celular celular)
        {
            string StrQuery = string.Format("delete from Celular where id = {0};", celular.id);
            db.ExecutaComando(StrQuery);
        }

        public Celular SelectIdCelular(Celular celular)
        {
            string StrQuery = string.Format("select * from Celular where id = {0};", celular.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objCelular = new Celular();

            while (myReader.Read())
            {
                objCelular.id = int.Parse(myReader["id"].ToString());
                objCelular.ddd = int.Parse(myReader["ddd"].ToString());
                objCelular.numero = int.Parse(myReader["numero"].ToString());
            }
            myReader.Close();
            return objCelular;
        }

        public void UpdateCelular(Celular celular)
        {
            string StrQuery = "";
            StrQuery += "update Celular set ";
            StrQuery += string.Format("ddd = '{0}', ", celular.ddd);
            StrQuery += string.Format("numero = '{0}' ", celular.numero);
            StrQuery += string.Format("where id = {0};", celular.id);

            db.ExecutaComando(StrQuery);
        }
    }
}