using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CadastroProdutos.Models
{
    public class Produto
    {
        public Produto()
        {
            Tipo = Nome = Codigo = string.Empty;
            Estoque = 0;
            Valor = decimal.Zero;
        }

        private static Produto _instance;
        public static Produto Instance { get { return _instance ?? (_instance = new Produto()); } }

        [Key]
        [Required(ErrorMessage = "O campo código deve ser preenchido.", AllowEmptyStrings = false)]
        [MaxLength(length: 10, ErrorMessage = "O código deve conter no máximo 10 caracteres")]
        [DisplayName("Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "O campo Nome deve ser preenchido.", AllowEmptyStrings = false)]
        [MaxLength(length: 500, ErrorMessage = "O nome deve conter no máximo 500 caracteres")]
        public string Nome { get; set; }

        [MaxLength(length: 50, ErrorMessage = "O nome deve conter no máximo 50 caracteres")]
        public string Tipo { get; set; }

        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Estoque inválido")]
        public int Estoque { get; set; }

        [DataType(DataType.Currency, ErrorMessage = "Valor inválido.")]
        public decimal Valor { get; set; }
    }
}