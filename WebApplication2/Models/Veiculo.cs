using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("Veiculos")]
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatorio informar o nome")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar a Placa")]
        public string? Placa { get; set; }  

        [Required(ErrorMessage = "Obrigatorio informar o Ano de fabricação")]
        [Display(Name = "Ano de Fabricação")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "Obrigatorio informar o Ano do Modelo")]
        [Display(Name = "Ano do Modelo")]
        public int AnoModelo { get; set; }

    }
}
