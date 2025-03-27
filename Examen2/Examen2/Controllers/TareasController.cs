using Microsoft.AspNetCore.Mvc;
using Examen2.Models;
using Examen2.Services;


namespace TestWebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TareasController : ControllerBase
{
    private readonly TareaService _tareaService;

    public TareasController(TareaService tareaService)
    {
        _tareaService = tareaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Tareas>>> ObtenerTareas()
    {
        var tareas = await _tareaService.ObtenerTareas();
        return Ok(tareas);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Tareas>> ObtenerTareaPorId(Guid id)
    {
        var tarea = await _tareaService.ObtenerTareaPorId(id);
        if (tarea == null) return NotFound("Tarea no encontrada");

        return Ok(tarea);
    }

    [HttpPost]
    public async Task<ActionResult> CrearTarea([FromBody] Tareas tareas)
    {
        if (tareas == null)
        {
            return BadRequest("Datos de la tarea vienen vacíos");
        }
        var nuevaTarea = await _tareaService.CrearTarea(tareas);
        return Ok(nuevaTarea);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> ActualizarTarea(Guid id, [FromBody] Tareas tareaActualizada)
    {
        if (tareaActualizada == null)
        {
            return BadRequest("Datos de la tarea vienen vacíos");
        }

        var response = await _tareaService.ActualizarTarea(id, tareaActualizada);

        if (response == false)
        {
            return NotFound("Tarea no encontrada en base de datos");
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> EliminarTarea(Guid id)
    {
        var response = await _tareaService.EliminarTarea(id);
        if (response == false)
        {
            return NotFound("Tarea no encontrada en base de datos");
        }
        return NoContent();
    }
}
