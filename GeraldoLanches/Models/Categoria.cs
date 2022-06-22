using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeraldoLanches.Models
{
    [Table("Categorias")]   
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

       [StringLength(100, ErrorMessage ="Maximo de 100 caracteres ultrapassado")]
       [Required(ErrorMessage ="Digite um nome, para a categoria")]
       [Display(Name ="Nome")]
        public string CategoriaNome { get; set; }

        [StringLength(200, ErrorMessage = "Maximo de 200 caracteres ultrapassado")]
        [Required(ErrorMessage = "Digite uma descrição, para a categoria")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public List<Lanche> Lanche { get; set; }

    }
}
