

using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APICadastro.Models
{
    [Table("Produtos")]//Incluindo referencia ao namespace //using System.ComponentModel.DataAnnotations.Schem

    public class Produto
    { 
    [Key]
            
    public int ProdutoId { get; set; }
       
        [Required]
        [StringLength(80)]
    public string? Nome { get; set; }
        [Required]
        [StringLength(80)]

    public string? Descricao { get; set; }

        [Required]
        [Column(TypeName ="decimal(10,2")]
    public decimal Valor { get; set; }

    public float Estoque { get; set;}
    public DateTime DataCadastro { get; set; }
    public int CadastroId { get; set; }

    [JsonIgnore]
    public Cadastro? cadastro { get; set; }
}

}