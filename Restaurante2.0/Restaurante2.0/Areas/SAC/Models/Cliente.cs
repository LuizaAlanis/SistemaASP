using MySql.Data.MySqlClient;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.SAC.Models
{
    public class Cliente
    {
        public conexaoDB db = new conexaoDB();

        /* TABELA
        
            id int AI PK 
            cpf varchar(15) 
            cliente varchar(30) 
            idCelular int
        */

        // Atributos

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "CPF")]
        [StringLength(15, ErrorMessage = "O limite é de 15 caracteres.")]
        public String cpf { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String nome { get; set; }

        [Required]
        [Display(Name = "Id Celular")]
        public int idCelular { get; set; }
        public virtual Celular celular { get; set; }


        // Métodos

        public void InsertCliente(Cliente cliente)
        {
            string strQuery = string.Format("insert into Cliente(id, cpf, cliente, idCelular) " +
                                         "values ({0},'{1}','{2}',{3});", cliente.id, cliente.cpf, cliente.nome, cliente.idCelular);

            db.ExecutaComando(strQuery);
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
                    nome = myReader["cliente"].ToString(),
                    idCelular = int.Parse(myReader["idCelular"].ToString())

                };
                ListaCliente.Add(objCliente);
            }
            myReader.Close();
            return ListaCliente;
        }

        public void DeleteCliente(Cliente cliente)
        {
            string StrQuery = string.Format("delete from Cliente where id = {0};", cliente.id);
            db.ExecutaComando(StrQuery);
        }

        public Cliente SelectIdCliente(Cliente cliente)
        {
            string StrQuery = string.Format("select * from Cliente where id = {0};", cliente.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objCliente = new Cliente();

            while (myReader.Read())
            {
                objCliente.id = int.Parse(myReader["id"].ToString());
                objCliente.cpf = myReader["cpf"].ToString();
                objCliente.nome = myReader["cliente"].ToString();
                objCliente.idCelular = int.Parse(myReader["idCelular"].ToString());
            }
            myReader.Close();
            return objCliente;
        }

        public void UpdateCliente(Cliente cliente)
        {
            string StrQuery = "";
            StrQuery += "update Cliente set ";
            StrQuery += string.Format("cpf = '{0}', ", cliente.cpf);
            StrQuery += string.Format("cliente = '{0}', ", cliente.nome);
            StrQuery += string.Format("idCelular = {0} ", cliente.idCelular);
            StrQuery += string.Format("where id = {0};", cliente.id);

            db.ExecutaComando(StrQuery);
        }
    }
}