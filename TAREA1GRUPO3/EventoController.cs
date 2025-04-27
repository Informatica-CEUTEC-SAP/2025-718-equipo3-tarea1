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
    
}


/* GET
    public IActionResult Index()
    {
        return View()
}*/