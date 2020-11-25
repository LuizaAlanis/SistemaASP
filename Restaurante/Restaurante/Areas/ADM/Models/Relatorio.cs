using MySql.Data.MySqlClient;
using Restaurante.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Restaurante.Areas.ADM.Models
{
    public class Relatorio
    {
        public conexaoDB db = new conexaoDB();

        /*
            BASE DE DADOS:

            id int primary key auto_increment,
            dataRelatorio date,
	        autor varchar(50) not null,
            departamento varchar(30) not null,
            titulo varchar(90) not null,
            corpo longtext not null
        */

        /* Atributos */

        [Display(Name = "Id")]
        public int id { get; set; }

        [Display(Name = "Data")]
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime dataRelatorio { get; set; }

        [Display(Name = "Autor(a)")]
        [Required]
        [StringLength(50, ErrorMessage = "O limite é de 50 caracteres.")]
        public String autor { get; set; }

        [Display(Name = "Departamento")]
        [Required]
        [StringLength(30, ErrorMessage = "O limite é de 30 caracteres.")]
        public String departamento { get; set; }

        [Display(Name = "Título")]
        [Required]
        [StringLength(90, ErrorMessage = "O limite é de 90 caracteres.")]
        public String titulo { get; set; }

        [Display(Name = "Corpo")]
        [Required]
        public String corpo { get; set; }

        /* Métodos */

        public void InsertRelatorio(Relatorio relatorio)
        {
            string strQuery = string.Format("insert into Relatorio(dataRelatorio, autor, departamento, titulo, corpo) " +
                                         "values ('{0}', '{1}', '{2}', '{3}', '{4}');", relatorio.dataRelatorio, relatorio.autor, relatorio.departamento, relatorio.titulo, relatorio.corpo);

            using (db = new conexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
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

        public void DeletRelatorio(Relatorio relatorio)
        {
            string StrQuery = string.Format("delete from Relatorio where id = '{0}';", relatorio.id);
            db.ExecutaComando(StrQuery);
        }

        public void UpdateRelatorio(Relatorio relatorio)
        {
            string StrQuery = "";
            StrQuery += "update Relatorio set ";
            StrQuery += string.Format("dataRelatorio = '{0}',", relatorio.dataRelatorio);
            StrQuery += string.Format("autor = '{0}',", relatorio.autor);
            StrQuery += string.Format("departamento = '{0}',", relatorio.departamento);
            StrQuery += string.Format("titulo = '{0}',", relatorio.titulo);
            StrQuery += string.Format("corpo = '{0}',", relatorio.corpo);
            StrQuery += string.Format("where id = {0};", relatorio.id);

            db.ExecutaComando(StrQuery);
        }

        public Relatorio SelectIdRelatorio(Relatorio relatorio)
        {
            string StrQuery = string.Format("select * from Relatorio where id = {0};", relatorio.id);
            MySqlDataReader myReader = db.RetornaRegistro(StrQuery);
            var objRelatorio = new Relatorio();

            while (myReader.Read())
            {
                dataRelatorio = DateTime.Parse(myReader["dataRelatorio"].ToString());
                autor = myReader["autor"].ToString();
                departamento = myReader["departamento"].ToString();
                titulo = myReader["titulo"].ToString();
                corpo = myReader["corpo"].ToString();
            }
            myReader.Close();
            return objRelatorio;
        }
    }
}