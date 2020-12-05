using MySql.Data.MySqlClient;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.RH.Models
{
    public class Funcionario
    {
        public conexaoDB db = new conexaoDB();

        /* TABELA
        
            id int AI PK 
            funcionario varchar(30) 
            cpf varchar(15) 
            dataNascimento date 
            sexo varchar(20) 
            idFuncionario int
        */

        // Atributos

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String nome { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [StringLength(15, ErrorMessage = "O limite é de 15 caracteres.")]
        public String cpf { get; set; }

        [Required]
        [Display(Name = "Data de nascimento")]
        public DateTime dataNascimento { get; set; }

        [Display(Name = "Sexo")]
        [StringLength(15, ErrorMessage = "O limite é de 15 caracteres.")]
        public String sexo { get; set; }

        [Required]
        [Display(Name = "Id cargo")]
        public int idCargo { get; set; }
        public virtual Cargo cargo { get; set; }


        // Métodos

        public void InsertFuncionario(Funcionario funcionario)
        {
            string strQuery = string.Format("insert into Funcionario(id, funcionario, cpf, dataNascimento, sexo, idCargo) " +
                                         "values ({0},'{1}','{2}','{3}','{4}',{5});", funcionario.id, funcionario.nome, funcionario.cpf, funcionario.dataNascimento.ToString("yyyy-MM-dd"), funcionario.sexo, funcionario.idCargo);

            db.ExecutaComando(strQuery);
        }

        public List<Funcionario> SelectFuncionario()
        {
            string StrQuery = "select * from Funcionario;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaFuncionario = new List<Funcionario>();

            while (myReader.Read())
            {
                var objFuncionario = new Funcionario()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    nome = myReader["funcionario"].ToString(),
                    cpf = myReader["cpf"].ToString(),
                    dataNascimento = DateTime.Parse(myReader["dataNascimento"].ToString()),
                    sexo = myReader["sexo"].ToString(),
                    idCargo = int.Parse(myReader["idCargo"].ToString())
                };
                ListaFuncionario.Add(objFuncionario);
            }
            myReader.Close();
            return ListaFuncionario;
        }

        public void DeleteFuncionario(Funcionario funcionario)
        {
            string StrQuery = string.Format("delete from Funcionario where id = {0};", funcionario.id);
            db.ExecutaComando(StrQuery);
        }

        public Funcionario SelectIdFuncionario(Funcionario funcionario)
        {
            string StrQuery = string.Format("select * from Funcionario where id = {0};", funcionario.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objFuncionario = new Funcionario();

            while (myReader.Read())
            {
                objFuncionario.id = int.Parse(myReader["id"].ToString());
                objFuncionario.nome = myReader["funcionario"].ToString();
                objFuncionario.cpf = myReader["cpf"].ToString();
                objFuncionario.dataNascimento = DateTime.Parse(myReader["dataNascimento"].ToString());
                objFuncionario.sexo = myReader["sexo"].ToString();
                objFuncionario.idCargo = int.Parse(myReader["idCargo"].ToString());
            }
            myReader.Close();
            return objFuncionario;
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            string StrQuery = "";
            StrQuery += "update Funcionario set ";
            StrQuery += string.Format("funcionario = '{0}', ", funcionario.nome);
            StrQuery += string.Format("cpf = '{0}', ", funcionario.cpf);
            StrQuery += string.Format("dataNascimento = '{0}', ", funcionario.dataNascimento.ToString("yyyy-MM-dd"));
            StrQuery += string.Format("sexo = '{0}', ", funcionario.sexo);
            StrQuery += string.Format("idCargo = {0} ", funcionario.idCargo);
            StrQuery += string.Format("where id = {0};", funcionario.id);

            db.ExecutaComando(StrQuery);
        }
    }
}