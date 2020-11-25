using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppLayout.Models
{
    public class Categoria
    {
        [Display(Name = "Código")]
        [Key]
        public int idCategoria { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string descricao { get; set; }
    }
}