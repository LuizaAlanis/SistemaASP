using MySql.Data.MySqlClient;
using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Areas.ADM.Models
{
    public class Produto
    {
        public conexaoDB db = new conexaoDB();

        /*
            BASE DE DADOS:

	        id int primary key auto_increment,
            nome varchar(50) not null,
            idCategoria int not null,
            capa varchar(200),
            valor decimal(6,2) not null,
            info mediumtext,
            validade date not null,
            quantidade int not null,
            promocao enum ('S','N'),
	        constraint fk_categoria foreign key (idCategoria) references Categoria(id)
        */

        /* Atributos */

        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Nome")]
        [Required]
        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        public String nome { get; set; }

        [Display(Name = "Id Categoria")]
        [Required]
        public virtual int idCategoria { get; set; }
        public Categoria categoria { get; set; } //enfim, preciso confirmar isso aqui

        //preciso ver como trabalhar com imagem também

        [Display(Name = "Valor")]
        [Required]
        public decimal valor { get; set; }

        [Display(Name = "Informações")]
        [Required]
        public String info { get; set; }

        [Display(Name = "Validade")]
        [Required]
        public DateTime validade { get; set; }

        [Display(Name = "Quantidade")]
        [Required]
        public int quantidade { get; set; }

        [Display(Name = "Promoção?")]
        [Required]
        public String promocao { get; set; }

        /* Métodos */

        public void InsertProduto(Produto produto)
        {
            string strQuery = string.Format("insert into Produto(nome, idCategoria, capa, valor, info, validade, quantidade, promocao) " +
                                         "values ('{0}',{1},'{2}',{3},'{4}','{5}',{6},'{7}');", produto.nome, produto.idCategoria, /*produto.capa*/ produto.valor, produto.info, produto.validade, produto.quantidade, produto.promocao);

            using (db = new conexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
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
                    nome = myReader["nome"].ToString(),
                    idCategoria = int.Parse(myReader["idCategoria"].ToString()),
                 // capa = myReader["capa"].ToString(),
                    valor = decimal.Parse(myReader["valor"].ToString()),
                    info = myReader["info"].ToString(),
                    validade = DateTime.Parse(myReader["validade"].ToString()),
                    quantidade = int.Parse(myReader["quantidade"].ToString()),
                    promocao = myReader["nome"].ToString()
                };
                ListaProduto.Add(objProduto);
            }
            myReader.Close();
            return ListaProduto;
        }

        public void DeletProduto(Produto produto)
        {
            string StrQuery = string.Format("delete from Produto where id = '{0}';", produto.id);
            db.ExecutaComando(StrQuery);
        }

        public void UpdateProduto(Produto produto)
        {
            string StrQuery = "";
            StrQuery += "update Produto set ";
            StrQuery += string.Format("nome = '{0}',", produto.nome);
            StrQuery += string.Format("idCategoria = {0},", produto.idCategoria);
         // StrQuery += string.Format("capa = '{0}',", produto.capa);
            StrQuery += string.Format("valor = {0},", produto.valor);
            StrQuery += string.Format("info = '{0}',", produto.info);
            StrQuery += string.Format("validade = '{0}',", produto.validade);
            StrQuery += string.Format("quantidade = {0},", produto.quantidade);
            StrQuery += string.Format("promocao = '{0}',", produto.promocao);
            StrQuery += string.Format("where id = {0};", produto.id);

            db.ExecutaComando(StrQuery);
        }

        public Produto SelectIdProduto(Produto produto)
        {
            string StrQuery = string.Format("select * from Produto where id = {0};", produto.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var objProduto = new Produto();

            while (myReader.Read())
            {
                nome = myReader["nome"].ToString();
                idCategoria = int.Parse(myReader["idCategoria"].ToString());
                // capa = myReader["capa"].ToString();
                valor = decimal.Parse(myReader["valor"].ToString());
                info = myReader["info"].ToString();
                validade = DateTime.Parse(myReader["validade"].ToString());
                quantidade = int.Parse(myReader["quantidade"].ToString());
                promocao = myReader["nome"].ToString();
            }
            myReader.Close();
            return objProduto;
        }
    }
}