using MySql.Data.MySqlClient;
using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Areas.SAC.Models
{
    public class Cliente
    {
        public conexaoDB db = new conexaoDB();

        /*
            BASE DE DADOS:

	        id int primary key auto_increment,
            cpf varchar(15) not null,
            nome varchar(30) not null ,
            idCelular int,
            idTelefone int,
            constraint fk_celular foreign key (idCelular) references Celular(id),
            constraint fk_telefone foreign key (idTelefone) references Telefone(id)
        */

        /* Atributos */

        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "CPF")]
        [Required]
        [StringLength(15, ErrorMessage = "O limite é de 15 caracteres.")]
        public String cpf { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String nome { get; set; }

        [Display(Name = "Celular")]
        [Required]
        public virtual int idCelular { get; set; }
        public Celular celular { get; set; }

        [Display(Name = "Telefone")]
        [Required]
        public virtual int idTelefone { get; set; }
        public Telefone telefone { get; set; }

        /* Métodos */

        public void InsertCliente(Cliente cliente)
        {
            string strQuery = string.Format("insert into Cliente(cpf, nome, idCelular, idTelefone) " +
                                         "values ('{0}','{1}',{2},{3});", cliente.cpf, cliente.nome, cliente.idCelular, cliente.idTelefone);

            using (db = new conexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Cliente> SelectCliente()
        {
            string StrQuery = "select * from Cliente;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaCliente = new List<Cliente>();

            while (myReader.Read())
            {
                var objCliente = new Cliente()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    cpf = myReader["cpf"].ToString(),
                    nome = myReader["nome"].ToString(),
                    idCelular = int.Parse(myReader["idCelular"].ToString()),
                    idTelefone = int.Parse(myReader["idTelefone"].ToString())
                };
                ListaCliente.Add(objCliente);
            }
            myReader.Close();
            return ListaCliente;
        }

        public void DeletCliente(Cliente cliente)
        {
            string StrQuery = string.Format("delete from Cliente where id = '{0}';", cliente.id);
            db.ExecutaComando(StrQuery);
        }

        public void UpdateCliente(Cliente cliente)
        {
            string StrQuery = "";
            StrQuery += "update Cliente set ";
            StrQuery += string.Format("cpf = '{0}',", cliente.cpf);
            StrQuery += string.Format("nome = '{0}',", cliente.nome);
            StrQuery += string.Format("idCelular = '{0}',", cliente.idCelular);
            StrQuery += string.Format("idTelefone = '{0}',", cliente.idTelefone);
            StrQuery += string.Format("where id = {0};", cliente.id);

            db.ExecutaComando(StrQuery);
        }

        public Cliente SelectIdCliente(Cliente cliente)
        {
            string StrQuery = string.Format("select * from Cliente where id = {0};", cliente.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var objCliente = new Cliente();

            while (myReader.Read())
            {
                cpf = myReader["cpf"].ToString();
                nome = myReader["nome"].ToString();
                idCelular = int.Parse(myReader["idCelular"].ToString());
                idTelefone = int.Parse(myReader["idTelefone"].ToString());
            }
            myReader.Close();
            return objCliente;
        }
    }
}