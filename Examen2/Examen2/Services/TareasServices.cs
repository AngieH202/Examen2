using Examen2.Data;
using Examen2.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen2.Services;

public class TareaService
{
    private readonly DataContext _context;

    public TareaService(DataContext context)
    {
        _context = context;
    }

    // Obtener todas las tareas
    public async Task<List<Tareas>> ObtenerTareas()
    {
        return await _context.Tareas.ToListAsync();
    }

    // Obtener una tarea por id
    public async Task<Tareas?> ObtenerTareaPorId(Guid id)
    {
        return await _context.Tareas.FirstOrDefaultAsync(t => t.Id == id);
    }

    // Crear una tarea
    public async Task<Tareas> CrearTarea(Tareas tarea)
    {
        tarea.Id = Guid.NewGuid();
        tarea.CreatedAt = DateTime.UtcNow;

        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();

        return tarea;
    }

    // Actualizar una tarea
    public async Task<bool> ActualizarTarea(Guid id, Tareas tareaActualizada)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return false;

        tarea.Nombre = tareaActualizada.Nombre;
        tarea.Descripcion = tareaActualizada.Descripcion;

        await _context.SaveChangesAsync();
        return true;
    }

    // Eliminar una tarea
    public async Task<bool> EliminarTarea(Guid id)
    {
        var tarea = await _context.Tareas.FindAsync(id);
        if (tarea == null) return false;

        _context.Tareas.Remove(tarea);
        await _context.SaveChangesAsync();
        return true;
    }
}
