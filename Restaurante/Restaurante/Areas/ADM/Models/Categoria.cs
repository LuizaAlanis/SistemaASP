using MySql.Data.MySqlClient;
using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Areas.ADM.Models
{
    public class Categoria
    {
        public conexaoDB db = new conexaoDB();

        /*
            BASE DE DADOS:

	        id int primary key auto_increment,
            nome varchar(30) not null
        */

        /* Atributos */

        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String nome { get; set; }

        /* Métodos */

        public void InsertCategoria(Categoria categoria)
        {
            string strQuery = string.Format("insert into Categoria(nome) " +
                                         "values ('{0}');", categoria.nome);

            using (db = new conexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Categoria> SelectCategoria()
        {
            string StrQuery = "select * from Categoria;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaCategoria = new List<Categoria>();

            while (myReader.Read())
            {
                var objCategoria = new Categoria()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    nome = myReader["nome"].ToString()
                };
                ListaCategoria.Add(objCategoria);
            }
            myReader.Close();
            return ListaCategoria;
        }

        public void DeletCategoria(Categoria categoria)
        {
            string StrQuery = string.Format("delete from Categoria where id = '{0}';", categoria.id);
            db.ExecutaComando(StrQuery);
        }

        public void UpdateCategoria(Categoria categoria)
        {
            string StrQuery = "";
            StrQuery += "update Categoria set ";
            StrQuery += string.Format("nome = '{0}',", categoria.nome);
            StrQuery += string.Format("where id = {0};", categoria.id);

            db.ExecutaComando(StrQuery);
        }

        public Categoria SelectIdCategoria(Categoria categoria)
        {
            string StrQuery = string.Format("select * from Categoria where id = {0};", categoria.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var objCategoria = new Categoria();

            while (myReader.Read())
            {
                nome = myReader["nome"].ToString();
            }
            myReader.Close();
            return objCategoria;
        }
    }
}