using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGI.Models;

public class Produto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome não pode ultrapassar 100 caracteres.")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O preço é obrigatório.")]
    [Range(0.01, 999999.99, ErrorMessage = "O preço deve ser maior que zero.")]
    [Column(TypeName = "decimal(10,2)")]
    [Display(Name = "Preço")]
    [DataType(DataType.Currency)]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "A quantidade é obrigatória.")]
    [Range(0, int.MaxValue, ErrorMessage = "A quantidade não pode ser negativa.")]
    [Display(Name = "Quantidade")]
    public int Quantidade { get; set; }
}
