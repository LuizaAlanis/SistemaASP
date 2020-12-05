using MySql.Data.MySqlClient;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestauranteMexicano.Areas.ADM.Models
{
    public class Categoria
    {
        public conexaoDB db = new conexaoDB();

        /* TABELA
        
	        id int primary key auto_increment,
            categoria varchar(30) not null
        */

        // Atributos

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Nome")]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String nome { get; set; }

        public ICollection<Produto> Produto { get; set; }

        // Métodos

        public void InsertCategoria(Categoria categoria)
        {
            string strQuery = string.Format("insert into Categoria(id, categoria) " +
                                         "values ({0},'{1}');", categoria.id, categoria.nome);

            db.ExecutaComando(strQuery);
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
                    nome = myReader["categoria"].ToString()
                };
                ListaCategoria.Add(objCategoria);
            }
            myReader.Close();
            return ListaCategoria;
        }

        public void DeleteCategoria(Categoria categoria)
        {
            string StrQuery = string.Format("delete from Categoria where id = {0};", categoria.id);
            db.ExecutaComando(StrQuery);
        }

        public Categoria SelectIdCategoria(Categoria categoria)
        {
            string StrQuery = string.Format("select * from Categoria where id = {0};", categoria.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objcategoria = new Categoria();

            while (myReader.Read())
            {
                objcategoria.id = int.Parse(myReader["id"].ToString());
                objcategoria.nome = myReader["categoria"].ToString();
            }
            myReader.Close();
            return objcategoria;
        }

        public void UpdateCategoria(Categoria categoria)
        {
            string StrQuery = "";
            StrQuery += "update Categoria set ";
            StrQuery += string.Format("categoria = '{0}' ", categoria.nome);
            StrQuery += string.Format("where id = {0};", categoria.id);

            db.ExecutaComando(StrQuery);
        }
    }
}