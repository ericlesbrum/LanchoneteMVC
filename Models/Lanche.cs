using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteMVC.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Nome")]
        [StringLength(80, MinimumLength = 10, ErrorMessage = "O {0} deve ter no mínimo {1} e o máximo {2}")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A descrição do lanche deve ser informada")]
        [Display(Name = "Descrição do Lanche")]
        [StringLength(140, MinimumLength = 20, ErrorMessage = "A {0} deve ter no mínimo {1} e o máximo {2}")]
        public string DescricaoCurta { get; set; }
        [Required(ErrorMessage = "A descrição detalhada do lanche deve ser informada")]
        [Display(Name = "Descrição detalhada do Lanche")]
        [StringLength(200, MinimumLength = 20, ErrorMessage = "A {0} deve ter no mínimo {1} e o máximo {2}")]
        public string DescricaoDetalhada { get; set; }
        [Required(ErrorMessage = "Informe o preo do lanche")]
        [Display(Name = "Preço")]
        [Column(TypeName = "decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage = "O preço deve estar entre 1 e 999,99")]
        public decimal Preco { get; set; }
        [Display(Name = "Caminho da Imagem Normal")]
        [StringLength(200, ErrorMessage = "A {0} deve ter no máximo {1} caracteres")]
        public string ImagemUrl { get; set; }
        [Display(Name = "Caminho da Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "A {0} deve ter no máximo {1} caracteres")]
        public string ImagemThumbnailUrl { get; set; }
        [Display(Name ="Preferido?")]
        public bool IsLanchePreferido { get; set; }
        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}