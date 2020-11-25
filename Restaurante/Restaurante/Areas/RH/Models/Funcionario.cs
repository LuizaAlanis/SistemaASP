using MySql.Data.MySqlClient;
using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Restaurante.Areas.RH.Models
{
    public class Funcionario
    {
        public conexaoDB db = new conexaoDB();

        /*
            BASE DE DADOS:

            Funcionario

	        id int primary key auto_increment,
            nome varchar(30) not null,               <- "campo renomeado para funcionario"
            cpf varchar(15) not null,
            dataNascimento date not null,
            sexo varchar(20),
            idCargo int not null,
            constraint fk_cargo foreign key (idCargo) references Cargo(id)
        */

        /* Atributos */

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String funcionario { get; set; }

        [Display(Name = "CPF")]
        [Required]
        [StringLength(15, ErrorMessage = "O limite é de 15 caracteres.")]
        public String cpf { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required]
        public DateTime dataNascimento { get; set; }

        [Display(Name = "Sexo")]
        [Required]
        [StringLength(15, ErrorMessage = "O limite é de 15 caracteres.")]
        public String sexo { get; set; }

        [Display(Name = "Cargo")]
        [Required]
        public virtual int idCargo { get; set; }
        public Cargo cargo { get; set; }

        public class Cargo
        {
            public int idCargo { get; set; }
            public string nomeCargo { get; set; }

            public ICollection<Cargo> cargo { get; set; }
        }


        /* Métodos */

        public void InsertFuncionario(Funcionario funcionario)
        {
            string strQuery = string.Format("insert into Funcionario(funcionario, cpf, dataNascimento, sexo, idCargo) " +
                                         "values ('{0}','{1}','{2}','{3}',{4});", funcionario.funcionario, funcionario.cpf, funcionario.dataNascimento, funcionario.sexo, funcionario.idCargo);

            using (db = new conexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
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
                    funcionario = myReader["funcionario"].ToString(),
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
            string StrQuery = string.Format("delete from Funcionario where id = '{0}';", funcionario.id);
            db.ExecutaComando(StrQuery);
        }

        public void UpdateFuncionario(Funcionario funcionario)
        {
            string StrQuery = "";
            StrQuery += "update Funcionario set ";
            StrQuery += string.Format("funcionario = '{0}',", funcionario.funcionario);
            StrQuery += string.Format("cpf = '{0}',", funcionario.cpf);
            StrQuery += string.Format("dataNascimento = '{0}',", funcionario.dataNascimento);
            StrQuery += string.Format("sexo = '{0}',", funcionario.sexo);
            StrQuery += string.Format("where id = {0};", funcionario.id);

            db.ExecutaComando(StrQuery);
        }

        public Funcionario SelectIdFuncionario(Funcionario funcionario)
        {
            string StrQuery = string.Format("select * from Funcionario where id = {0};", funcionario.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var objFuncionario = new Funcionario();

            while (myReader.Read())
            {
                funcionario.funcionario = myReader["funcionario"].ToString();
                cpf = myReader["cpf"].ToString();
                dataNascimento = DateTime.Parse(myReader["dataNascimento"].ToString());
                sexo = myReader["sexo"].ToString();
                idCargo = int.Parse(myReader["idCargo"].ToString());
            }
            myReader.Close();
            return objFuncionario;
        }
    }
}