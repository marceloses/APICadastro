using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace APICadastro.Models
{
    [Table("user_sistema")]

    /*
    * Model -> Modelo de dominio 
    * Classe -> User_Sistema iremos criar propriedades que irão representar as informações que eu quero gerenciar
    * */

    public class UserSistema
        {
        [Key]    
        public int CodUserId { get; set; }

        [Required]
        [StringLength(45)]
        public string? UserNome { get; set; }

        [Required]
        [StringLength(45)]
        public string? UserSetor { get; set; }
        
        [Required]
        [StringLength(45)]
        public string? UserSenha { get; set; }

        [Required]
        [StringLength(1)]
        public string? UserNivel { get; set; }

        [Required]
        [StringLength(15)]
        public string? UserLogin { get; set; }
        //[JsonIgnore]

    }
}
