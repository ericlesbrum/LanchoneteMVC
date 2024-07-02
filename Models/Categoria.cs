using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteMVC.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="informe o nome da categoria")]
        [StringLength(100, ErrorMessage = "O Tamanho máximo é 100 caracteres")]
        [Display(Name ="Nome")]
        public string CategoriaNome { get; set; }
        [Required(ErrorMessage ="informe a descrição da categoria")]
        [StringLength(200, ErrorMessage = "O Tamanho máximo é 100 caracteres")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        public List<Lanche> Lanches { get; set; }
    }
}