using MySql.Data.MySqlClient;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.RH.Models
{
    public class Cargo
    {
        public conexaoDB db = new conexaoDB();

        /* TABELA
        
            id int AI PK 
            cargo varchar(30) 
            descricao mediumtext 
            valor decimal(6,2)
        */

        // Atributos

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Cargo")]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String nome { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public String descricao { get; set; }

        [Required]
        [Display(Name = "Salário")]
        public decimal valor { get; set; }

        public ICollection<Funcionario> Funcionario { get; set; }


        // Métodos

        public void InsertCargo(Cargo cargo)
        {
            string strQuery = string.Format("insert into Cargo(id, cargo, descricao, valor) " +
                                         "values ({0},'{1}','{2}',{3});", cargo.id, cargo.nome, cargo.descricao, cargo.valor);

            db.ExecutaComando(strQuery);
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
                    nome = myReader["cargo"].ToString(),
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

        public Cargo SelectIdCargo(Cargo cargo)
        {
            string StrQuery = string.Format("select * from Cargo where id = {0};", cargo.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objCargo = new Cargo();

            while (myReader.Read())
            {
                objCargo.id = int.Parse(myReader["id"].ToString());
                objCargo.nome = myReader["cargo"].ToString();
                objCargo.descricao = myReader["descricao"].ToString();
                objCargo.valor = decimal.Parse(myReader["valor"].ToString());
            }
            myReader.Close();
            return objCargo;
        }

        public void UpdateCargo(Cargo cargo)
        {
            string StrQuery = "";
            StrQuery += "update Cargo set ";
            StrQuery += string.Format("cargo = '{0}', ", cargo.nome);
            StrQuery += string.Format("descricao = '{0}', ", cargo.descricao);
            StrQuery += string.Format("valor = '{0}' ", cargo.valor);
            StrQuery += string.Format("where id = {0};", cargo.id);

            db.ExecutaComando(StrQuery);
        }
    }
}