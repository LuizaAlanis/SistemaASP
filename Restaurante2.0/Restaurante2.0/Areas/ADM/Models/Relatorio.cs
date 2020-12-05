using MySql.Data.MySqlClient;
using RestauranteMexicano.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestauranteMexicano.Areas.ADM.Models
{
    public class Relatorio
    {
        public conexaoDB db = new conexaoDB();

        /* TABELA
        
            id int AI PK 
            dataRelatorio date 
            autor varchar(50) 
            departamento varchar(30) 
            titulo varchar(90) 
            corpo longtext
        */

        // Atributos

        [Key]
        [Display(Name = "Id")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Data")]
        public DateTime dataRelatorio { get; set; }

        [Required]
        [Display(Name = "Autor(a)")]
        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        public String autor { get; set; }

        [Required]
        [Display(Name = "Departamento")]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String departamento { get; set; }

        [Required]
        [Display(Name = "Titulo")]
        [StringLength(90, ErrorMessage = "O limite é de 90 caracteres.")]
        public String titulo { get; set; }

        [Required]
        [Display(Name = "Corpo")]
        public String corpo { get; set; }


        // Métodos

        public void InsertRelatorio(Relatorio relatorio)
        {
            string strQuery = string.Format("insert into Relatorio(id, dataRelatorio, autor, departamento, titulo, corpo) " +
                                         "values ({0},'{1}','{2}','{3}','{4}','{5}');", relatorio.id, relatorio.dataRelatorio.ToString("yyyy-MM-dd"), relatorio.autor, relatorio.departamento, relatorio.titulo, relatorio.corpo);

            db.ExecutaComando(strQuery);
        }

        public List<Relatorio> SelectRelatorio()
        {
            string StrQuery = "select * from Relatorio;";
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var ListaRelatorio = new List<Relatorio>();

            while (myReader.Read())
            {
                var objRelatorio = new Relatorio()
                {
                    id = int.Parse(myReader["id"].ToString()),
                    dataRelatorio = DateTime.Parse(myReader["dataRelatorio"].ToString()),
                    autor = myReader["autor"].ToString(),
                    departamento = myReader["departamento"].ToString(),
                    titulo = myReader["titulo"].ToString(),
                    corpo = myReader["corpo"].ToString()
                };
                ListaRelatorio.Add(objRelatorio);
            }
            myReader.Close();
            return ListaRelatorio;
        }

        public void DeleteRelatorio(Relatorio relatorio)
        {
            string StrQuery = string.Format("delete from Relatorio where id = {0};", relatorio.id);
            db.ExecutaComando(StrQuery);
        }

        public Relatorio SelectIdRelatorio(Relatorio relatorio)
        {
            string StrQuery = string.Format("select * from Relatorio where id = {0};", relatorio.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);

            var objRelatorio = new Relatorio();

            while (myReader.Read())
            {
                objRelatorio.dataRelatorio = DateTime.Parse(myReader["dataRelatorio"].ToString());
                objRelatorio.autor = myReader["autor"].ToString();
                objRelatorio.departamento = myReader["departamento"].ToString();
                objRelatorio.titulo = myReader["titulo"].ToString();
                objRelatorio.corpo = myReader["corpo"].ToString();
            }
            myReader.Close();
            return objRelatorio;
        }

        public void UpdateRelatorio(Relatorio relatorio)
        {
            string StrQuery = "";
            StrQuery += "update Relatorio set ";
            StrQuery += string.Format("dataRelatorio = '{0}', ", relatorio.dataRelatorio.ToString("yyyy-MM-dd"));
            StrQuery += string.Format("autor = '{0}', ", relatorio.autor);
            StrQuery += string.Format("departamento = '{0}', ", relatorio.departamento);
            StrQuery += string.Format("titulo = '{0}', ", relatorio.titulo);
            StrQuery += string.Format("corpo = '{0}' ", relatorio.corpo);
            StrQuery += string.Format("where id = {0};", relatorio.id);

            db.ExecutaComando(StrQuery);
        }
    }
}