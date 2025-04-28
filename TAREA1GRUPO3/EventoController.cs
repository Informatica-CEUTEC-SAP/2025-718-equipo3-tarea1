using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace TAREA1GRUPO3;

[ApiController]
[Route("api/[controller]")]


public class EventoController : Controller
{
    static private List<Evento> eventos = new List<Evento>
    {
        new Evento
        {
            Id = 1,
            Nombre = "Recaudacion de fondos para orfanatos locales",
            Ciudad = "San Pedro sula",
            Categoria = "Comunitario",
            Fecha = DateTime.Now,
            Participantes = new List<Participantes>
            {
                new Participantes { DNI = "0801200821824", Email = "isaacdrums16@gmail.com", Nombre = "Wilmer" }
            }

        },
        new Evento
        {
            Id = 2,
            Nombre = "Inauguracion de starbucks",
            Ciudad = "Roatan",
            Categoria = "Local/negocio",
            Fecha = DateTime.Now,
            Participantes = new List<Participantes>()
        }

    };

    [HttpGet("eventos")]
    public IActionResult Eventos()
    {
        return Ok(eventos);
    }

    [HttpGet("eventos/{id}")]

    public IActionResult Evento([FromRoute] int id)
    {
        var evento = eventos.FirstOrDefault(x => x.Id == id);
        if (evento == null)
        {
            return NotFound();
        }

        return Ok(evento);
    }

    [HttpPost("eventos")]
    public IActionResult AgregarEvento([FromBody] Evento nuevoEvento)
    {
        if (nuevoEvento == null)
            return BadRequest();
        
        nuevoEvento.Id = eventos.Max(x => x.Id) + 1;
        eventos.Add(nuevoEvento);
        return CreatedAtAction(nameof(Evento),new { Id = nuevoEvento.Id }, nuevoEvento);
    }
  }




/* GET
    public IActionResult Index()
    {
        return View()
}*/