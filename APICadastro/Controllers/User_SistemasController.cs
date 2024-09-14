using APICadastro.Context;
using APICadastro.Models;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace APICadastro.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class User_SistemasController : ControllerBase
    {
        private readonly AppDbContext _context; // referência a pasta context onde está definido a pasta de contexto

        public User_SistemasController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public ActionResult<IEnumerable<UserSistema>> Get()
        {
            var sistemas = _context.user_sistemas.AsNoTracking().Take(3).ToList();
            //if (sistemas is null)
            //{
                //return NotFound("Não Localizado");
            //}
            return sistemas;
        }


        [HttpGet("{id:int}", Name = "Obter o Usuario")]

        public ActionResult<UserSistema> Get(int id)
        {
            var sistemas = _context.user_sistemas.FirstOrDefault(p => p.CodUserId == id);
            if (sistemas is null)
            {
                return NotFound("Não localizado");
            }
            return sistemas;
        }
    }
}
