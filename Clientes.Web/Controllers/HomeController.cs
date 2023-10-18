using Clientes.DAO;
using Clientes.DAO.DBContext;
using Clientes.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Clientes.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
        

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpGet]
        public List<Cliente> Get()
        {
            ClientedbContext context = new ClientedbContext();
            var clientes = context.Clientes.ToList();
            return clientes;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id) 
        {
            ClientedbContext context = new ClientedbContext();
            var clientes = context.Clientes.ToList();
            var buscarPorId = clientes.Find(x => x.Id == id);
            if(buscarPorId == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(buscarPorId);
            }
            
        }

        [HttpGet("{buscar}")]
        public IActionResult Buscar(string nombre)
        {
            ClientedbContext context = new ClientedbContext();
            var clientes = context.Clientes.ToList();
            if (!string.IsNullOrEmpty(nombre))
            {
                var clientes2 = clientes.Where(x => x.Nombres == nombre);
                return Ok(clientes2);
            }
            else
            {
                return NotFound();
            }
            

        }


        [HttpPost]
        public IActionResult Post([FromBody]Cliente cliente)
        {
            ClientedbContext context = new ClientedbContext();
            var clientes = context.Clientes.ToList();
            clientes.Add(cliente);
            context.SaveChanges();
            return Ok(clientes);
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            ClientedbContext context = new ClientedbContext();
            var clientes = context.Clientes.ToList();
            clientes[id] = cliente;
            return Ok(clientes);
        }

       

    }
}