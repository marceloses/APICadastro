using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace APICadastro.Models;
[Table("Cadastros")]
//Teste
public class Cadastro
{
    public Cadastro() 
    { 
        Produtos = new Collection<Produto>();
    }
    [Key]
    public int CadastroId { get; set; }

    [Required]
    [StringLength(50)]   
    public string? Nome { get; set; }
    
    public string? Informacao { get; set; }
    public string? UF { get; set; }
    public string? Cidade { get; set; }

    public string? Bairro { get; set; }

    public string? Cep { get; set; }

    public int? CodUser { get; set; }
    public ICollection<Produto>? Produtos { get; set; }
}
