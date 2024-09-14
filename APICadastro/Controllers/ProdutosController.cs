using APICadastro.Context;
using APICadastro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

//Teste
//Testando Pull requests
//Alteração feita

namespace APICadastro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Produto>> Get()//Usando o método "actionResult, podemos retornar tudo
        {
            var produtos = _context.Produtos.AsNoTracking().Take(3).ToList();
            if (produtos is null)
            {
                return NotFound("Produtos não encontrados...");//O NotFound vem da classe "ControllerBase" apertando F12 sobre o NotFound

            }
            return produtos;
        }


        [HttpGet("{id:int}", Name = "Obter Produto")] // Definimos o 'ID' que esta vindo pelo request
                             //Método publico / obter o Cadastro pelo 'ID'
        public ActionResult<Produto> Get(int id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
            //Produto id tem que ser igual ao produto que estou recebendo
            if (produto is null)
            {
                return NotFound("Produto não encontrato...");

            }
            return produto;
        }
     

        /* Criando um método "action" para cadastro [httpPost]
         * 
         * 
         **/
        
        [HttpPost]
        public ActionResult Post(Produto produto)
        {
            if (produto is null)
                return BadRequest();

            _context.Produtos.Add(produto);//Utilizando a instancia do contexto, inclui o cadastro no contexto
            _context.SaveChanges();//Persistindo e salvando no Banco de dados

            return new CreatedAtRouteResult("Obter Produto", 
                new { id = produto.ProdutoId }, produto);
            

        }

        [HttpPut("{id:int}")]

        public ActionResult Put(int id, Produto produto) //Esse objeto será enviado no corpo do request
        {
            if (id != produto.ProdutoId)
            {
                return BadRequest();
            }
            _context.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(produto);
        }

        [HttpDelete("{id:int}")]

        public ActionResult Delete(int id) 
        {
            var produto = _context.Produtos.FirstOrDefault(p=>p.ProdutoId == id);
            if (produto is null)
            {
                return NotFound("Produo não localizado...");

            }
            _context.Produtos.Remove(produto); 
            _context.SaveChanges();

            return Ok(produto);
        }


    }
}

    