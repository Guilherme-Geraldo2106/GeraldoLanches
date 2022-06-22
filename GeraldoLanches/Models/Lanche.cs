using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraldoLanches.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [StringLength(80, MinimumLength = 10, ErrorMessage = "O nome deve conter de 10 a 80 caracteres")]
        [Required(ErrorMessage = "Digite um nome, para o lanche")]
        [Display(Name = "Nome do Lanche")]
        public string Nome { get; set; }

        [StringLength(200, MinimumLength = 20,  ErrorMessage = "A descrição curta, deve ter entre 20 e 200 caracteres")]
        [Required(ErrorMessage = "Digite uma pequena descrição, para o lanche")]
        [Display(Name = "Descrição Curta")]
        public string DescricaoCurta { get; set; }

        [StringLength(300, ErrorMessage = "Maximo de 300 caracteres ultrapassado")]
        [Display(Name = "Descrição detalhada")]
        public string DescricaoDetalhada { get; set; }

        [Column(TypeName ="decimal(10,2)")]
        [Required(ErrorMessage = "Digite um Preço")]
        [Display(Name = "Preço do lanche")]
        [Range(1,999.99, ErrorMessage = "O preço deve estar entre 1 e 999.99")]
        public decimal Preco { get; set; }
      
        [Display(Name = "Imagem normal")]
        public string ImagemURL { get; set; }

        [Display(Name ="Imagem miniatura")]
        public string ImagemThumbnailUrl { get; set; }

        [Display(Name ="Preferido ?")]
        public bool IsLanchePreferido { get; set; }

        [Display(Name ="Em estoque ?")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

    }
}
