using APICadastro.Context;
using APICadastro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
//Teste

namespace APICadastro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CadastrosController : ControllerBase
    {
        private readonly AppDbContext _context;//injeção de dependencia na minha classe de contexto

        public CadastrosController(AppDbContext context)//Injeção de construtor 
        {
            _context = context;
        }

        /*
        [HttpGet("Produtos")]

        public ActionResult<IEnumerable<Cadastro>> GetCategoriasCadastros()

        {
            return _context.Cadastros.Include(p=> p.Produtos). Where (c=> c.CadstroId <= 5).ToList();
        }
        */

        [HttpGet]
        public ActionResult<IEnumerable<Cadastro>> Get()
        {
            return _context.Cadastros.AsNoTracking().Take(3).ToList();
            //AsnoTracking -> Para consultas do verbo GET, para nao sobrecarregar o sistema, melhora o desempenho
            //return _context.Cadastros.ToList();

        }

        [HttpGet("{id:int}", Name = "Obter Cadastro")]

        public ActionResult<Cadastro> Get(int id)
        {
            var cadastro = _context.Cadastros.FirstOrDefault(p => p.CadastroId == id);

            if (cadastro == null)
            {
                return NotFound("Categoria não localizada...");
            }
            return Ok(cadastro);
        }



        [HttpPost]
        public ActionResult Post(Cadastro cadastro)
        {
            if (cadastro is null)
                return BadRequest();

            _context.Cadastros.Add(cadastro);// Utilizando a instancia do contexto, inclui o cadastro no contexto
            _context.SaveChanges();

            return new CreatedAtRouteResult("Obter Cadastro",
                new { id = cadastro.CadastroId }, cadastro);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id,Cadastro cadastro) 
        {
            if (id != cadastro.CadastroId)
            {
                return BadRequest();
            }
            _context.Entry(cadastro).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok(cadastro);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id) 
        {
            var Cadastro = _context.Cadastros.FirstOrDefault(p => p.CadastroId == id);
            
            if (Cadastro == null)
            {
                return NotFound("Cadastro não encontrado...");
            }
            _context.Cadastros.Remove(Cadastro);
            _context.SaveChanges();
            return Ok(Cadastro);
        }
    }
}
