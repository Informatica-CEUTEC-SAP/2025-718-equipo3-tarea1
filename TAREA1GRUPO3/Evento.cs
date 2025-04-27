namespace TAREA1GRUPO3;

public class Evento
{
    public int Id { get; set; } 
    public string Nombre { get; set; }
    public string Ciudad { get; set; }
    public string Categoria { get; set; }
    public DateTime Fecha { get; set; }
    public List<Participantes> Participantes{ get; set; } 
}