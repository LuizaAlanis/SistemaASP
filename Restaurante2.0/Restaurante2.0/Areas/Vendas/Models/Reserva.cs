using MySql.Data.MySqlClient;
using RestauranteMexicano.Areas.ADM.Models;
using RestauranteMexicano.Areas.SAC.Models;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.Vendas.Models
{
    public class Reserva
    {
        public conexaoDB db = new conexaoDB();

        /*
            RESERVA

            id int AI PK 
            idMesa int 
            quantidadeCadeiras int 
            dataReserva date 
            hora varchar(15) 
            idCliente int
         */

        // Atributos

        [Key]
        public int id { get; set; }

        [Required]
        [Display(Name = "Mesa")]
        public int idMesa { get; set; }
        public virtual Mesa mesa { get; set; }

        [Required]
        public int quantidadeCadeiras { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime dataReserva { get; set; }

        [Required]
        [Display(Name = "Hora")]
        public string hora { get; set; }

        [Required]
        [Display(Name = "Id Cliente")]
        public int idCliente { get; set; }
        public virtual Cliente cliente { get; set; }

        // Métodos

        public void InsertReserva(Reserva reserva)
        {
            string strQuery = string.Format("insert into Reserva(id, idMesa, quantidadeCadeiras, dataReserva, hora, idCliente) " +
                                         "values ({0},{1},{2},'{3}','{4}',{5});", reserva.id, reserva.idMesa, reserva.quantidadeCadeiras, reserva.dataReserva.ToString("yyyy-MM-dd"), reserva.hora, reserva.idCliente);

            db.ExecutaComando(strQuery);
        }

        public List<Reserva> SelectReserva()
        {
            string StrQuery = "select * from Reserva;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaReserva = new List<Reserva>();

            while (myReader.Read())
            {
                var objReserva = new Reserva()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    idMesa = int.Parse(myReader["idMesa"].ToString()),
                    quantidadeCadeiras = int.Parse(myReader["quantidadeCadeiras"].ToString()),
                    dataReserva = DateTime.Parse(myReader["dataReserva"].ToString()),
                    hora = myReader["hora"].ToString(),
                    idCliente = int.Parse(myReader["idCliente"].ToString())
                };
                ListaReserva.Add(objReserva);
            }
            myReader.Close();
            return ListaReserva;
        }

        public void DeleteReserva(Reserva reserva)
        {
            string StrQuery = string.Format("delete from Reserva where id = {0};", reserva.id);
            db.ExecutaComando(StrQuery);
        }

        public Reserva SelectIdReserva(Reserva reserva)
        {
            string StrQuery = string.Format("select * from Reserva where id = {0};", reserva.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objReserva = new Reserva();

            while (myReader.Read())
            {
                objReserva.id = int.Parse(myReader["id"].ToString());
                objReserva.idMesa = int.Parse(myReader["idMesa"].ToString());
                objReserva.quantidadeCadeiras = int.Parse(myReader["quantidadeCadeiras"].ToString());
                objReserva.dataReserva = DateTime.Parse(myReader["dataReserva"].ToString());
                objReserva.hora = myReader["hora"].ToString();
                objReserva.idCliente = int.Parse(myReader["idCliente"].ToString());
            }
            myReader.Close();
            return objReserva;
        }

        public void UpdateReserva(Reserva reserva)
        {
            string StrQuery = "";
            StrQuery += "update Reserva set ";
            StrQuery += string.Format("idMesa = {0}, ", reserva.idMesa);
            StrQuery += string.Format("quantidadeCadeiras = {0}, ", reserva.quantidadeCadeiras);
            StrQuery += string.Format("dataReserva = '{0}', ", reserva.dataReserva.ToString("yyyy-MM-dd"));
            StrQuery += string.Format("hora = '{0}', ", reserva.hora);
            StrQuery += string.Format("idCliente = {0} ", reserva.idCliente);
            StrQuery += string.Format("where id = {0};", reserva.id);

            db.ExecutaComando(StrQuery);
        }
    }
}