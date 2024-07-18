using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanchoneteMVC.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome")]
        [StringLength(50)]
        public string SobreNome { get; set; }
        [Required(ErrorMessage = "Informe o seu endereço")]
        [StringLength(100)]
        [Display(Name = "Endereço")]
        public string Endereco1 { get; set; }
        [StringLength(100)]
        [Display(Name = "Complemento")]
        public string Endereco2 { get; set; }
        [Required(ErrorMessage = "Informe o seu CEP")]
        [StringLength(10, MinimumLength = 8)]
        [Display(Name = "CEP")]
        public string Cep { get; set; }
        [StringLength(10)]
        public string Estado { get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Informe o email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/)", ErrorMessage = "O email não possui um formato correto")]
        public string Email { get; set; }
        [ScaffoldColumn(false)]
        [Column(TypeName ="decimal(18,2)")]
        [Display(Name ="Total do Pedido")]
        public decimal PedidoTotal { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name ="Itens do Pedido")]
        public int TotalItensPedido { get; set; }
        [Display(Name ="Data do Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString ="{0 dd/MM/yyyy hh:mm}",ApplyFormatInEditMode =true)]
        public DateTime PedidoEnviado { get; set; }
        [Display(Name ="Data Envio Pedido")]
        [DataType(DataType.Text)]
        [DisplayFormat(DataFormatString ="{0 dd/MM/yyyy hh:mm}",ApplyFormatInEditMode =true)]
        public DateTime? PedidoEntregueEm { get; set; }

        public List<PedidoDetalhe> PedidoItens { get; set; }
    }
}