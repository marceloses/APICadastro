using APICadastro.Models;
using Microsoft.EntityFrameworkCore;
// Testando

//Classe de contexto erda da classe " :DbContext "

//Nesta classe definimos o mapeamento entre as Entidades e as Tabelas
/*
Dbcontext -> Representa uma sessão com o banco de dados sendo a ponte entre as entidades de dominio do
banco de dados
 */

//DbSet<T> ->Representa uma coleção de entidades no contexto que podem ser consultadas  no banco de dados

namespace APICadastro.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        //Análise
        //Mapeando a entidade Cadastro
        //Referencias a classe de onde vem o Cadastro/Produto linha 13 e 14
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<UserSistema> user_sistemas { get; set;}
    }
}
