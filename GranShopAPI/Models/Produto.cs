using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranShopAPI.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Categoria")]
        public int CategoriaID { get; set; }
        public Categoria Categoria { get; set; }


        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(300)]
        public string Descricao { get; set; }

        [Required]
        public int Estoque { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorCusto { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorVenda { get; set; }

        [Required]
        public bool Destaque { get; set; }
    }
}