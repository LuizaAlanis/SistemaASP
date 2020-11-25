using MySql.Data.MySqlClient;
using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Areas.RH.Models
{
    public class Cargo
    {
        public conexaoDB db = new conexaoDB();

        /*
            BASE DE DADOS:

            Cargo

            id int primary key auto_increment
            nome varchar(30) not null,               <- "campo renomeado para cargo"
            descricao mediumtext,
            valor decimal(6,2) not null
	    
        */

        /* Atributos */

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Cargo")]
        [Required]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String cargo { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public String descricao { get; set; }

        [Display(Name = "Salário")]
        [Required]
        public decimal valor { get; set; }


        /* Métodos */

        public void InsertCargo(Cargo cargo)
        {
            string strQuery = string.Format("insert into Cargo(cargo, descricao, valor) " +
                                         "values ('{0}','{1}',{2});", cargo.cargo, cargo.descricao, cargo.valor);

            using (db = new conexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Cargo> SelectCargo()
        {
            string StrQuery = "select * from Cargo;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaCargo = new List<Cargo>();

            while (myReader.Read())
            {
                var objCargo = new Cargo()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    cargo = myReader["cargo"].ToString(),
                    descricao = myReader["descricao"].ToString(),
                    valor = decimal.Parse(myReader["valor"].ToString())
                };
                ListaCargo.Add(objCargo);
            }
            myReader.Close();
            return ListaCargo;
        }

        public void DeleteCargo(Cargo cargo)
        {
            string StrQuery = string.Format("delete from Cargo where id = {0};", cargo.id);
            db.ExecutaComando(StrQuery);
        }

        public void UpdateCargo(Cargo cargo)
        {
            string StrQuery = "";
            StrQuery += "update Cargo set ";
            StrQuery += string.Format("cargo = '{0}',", cargo.cargo);
            StrQuery += string.Format("descricao = '{0}',", cargo.descricao);
            StrQuery += string.Format("valor = {0},", cargo.valor);
            StrQuery += string.Format("where id = {0};", cargo.id);

            db.ExecutaComando(StrQuery);
        }

        public Cargo SelectIdCargo(Cargo cargo)
        {
            string StrQuery = string.Format("select * from Cargo where id = {0};", cargo.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var objCargo = new Cargo();

            while (myReader.Read())
            {
                cargo.cargo = myReader["cargo"].ToString();
                descricao = myReader["descricao"].ToString();
                valor = decimal.Parse(myReader["valor"].ToString());
            }
            myReader.Close();
            return objCargo;
        }
    }
}