using MySql.Data.MySqlClient;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.ADM.Models
{
    public class Produto
    {
        public conexaoDB db = new conexaoDB();

        /* TABELA
        
            id int AI PK 
            produto varchar(50) 
            idCategoria int 
            capa varchar(200) 
            valor decimal(6,2) 
            info mediumtext 
            validade date 
            quantidade int 
            promocao enum('S','N')
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
        [Display(Name = "Categoria")]
        public int idCategoria { get; set; }
        public virtual Categoria categoria { get; set; }

        public String capa { get; set; }

        [Required]
        [Display(Name = "Preço")]
        public decimal valor { get; set; }

        public String info { get; set; }

        [Required]
        [Display(Name = "Data de validade")]
        public DateTime validade { get; set; }

        [Display(Name = "Quantidade")]
        public int quantidade { get; set; }

        [Display(Name = "Em promoção")]
        public string promocao { get; set; }


        // Métodos

        public void InsertProduto(Produto produto)
        {
            string strQuery = string.Format("insert into Produto(id, produto, idCategoria, capa, valor, info, validade, quantidade, promocao) " +
                                         "values ({0},'{1}',{2},'{3}',{4},'{5}','{6}',{7},'{8}');", produto.id, produto.nome, produto.idCategoria, produto.capa, produto.valor, 
                                         produto.info, produto.validade.ToString("yyyy-MM-dd"), produto.quantidade, produto.promocao);

            db.ExecutaComando(strQuery);
        }

        public List<Produto> SelectProduto()
        {
            string StrQuery = "select * from Produto;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaProduto = new List<Produto>();

            while (myReader.Read())
            {
                var objProduto = new Produto()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    nome = myReader["produto"].ToString(),
                    idCategoria = int.Parse(myReader["idCategoria"].ToString()),
                    capa = myReader["capa"].ToString(),
                    valor = decimal.Parse(myReader["valor"].ToString()),
                    info = myReader["info"].ToString(),
                    validade = DateTime.Parse(myReader["validade"].ToString()),
                    quantidade = int.Parse(myReader["quantidade"].ToString()),
                    promocao = myReader["promocao"].ToString()
                };
                ListaProduto.Add(objProduto);
            }
            myReader.Close();
            return ListaProduto;
        }

        public void DeleteProduto(Produto produto)
        {
            string StrQuery = string.Format("delete from Produto where id = {0};", produto.id);
            db.ExecutaComando(StrQuery);
        }

        public Produto SelectIdProduto(Produto produto)
        {
            string StrQuery = string.Format("select * from Produto where id = {0};", produto.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objproduto = new Produto();

            while (myReader.Read())
            {

                objproduto.nome = myReader["produto"].ToString();
                objproduto.idCategoria = int.Parse(myReader["idCategoria"].ToString());
                objproduto.capa = myReader["capa"].ToString();
                objproduto.valor = decimal.Parse(myReader["valor"].ToString());
                objproduto.info = myReader["info"].ToString();
                objproduto.validade = DateTime.Parse(myReader["validade"].ToString());
                objproduto.quantidade = int.Parse(myReader["quantidade"].ToString());
                objproduto.promocao = myReader["promocao"].ToString();
            }
            myReader.Close();
            return objproduto;
        }

        public void UpdateProduto(Produto produto)
        {
            string StrQuery = "";
            StrQuery += "update Produto set ";
            StrQuery += string.Format("produto = '{0}', ", produto.nome);
            StrQuery += string.Format("idCategoria = '{0}', ", produto.idCategoria);
            StrQuery += string.Format("capa = '{0}', ", produto.capa);
            StrQuery += string.Format("valor = '{0}', ", produto.valor);
            StrQuery += string.Format("info = '{0}', ", produto.info);
            StrQuery += string.Format("validade = '{0}', ", produto.validade.ToString("yyyy-MM-dd"));
            StrQuery += string.Format("quantidade = '{0}', ", produto.quantidade);
            StrQuery += string.Format("promocao = '{0}' ", produto.promocao);
            StrQuery += string.Format("where id = {0};", produto.id);

            db.ExecutaComando(StrQuery);
        }
    }
}