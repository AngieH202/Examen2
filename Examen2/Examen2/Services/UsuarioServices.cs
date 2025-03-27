using Examen2.Data;
using Examen2.Models;
using Microsoft.EntityFrameworkCore;



namespace Examen2.Services;

public class UsuarioService
{
    private readonly DataContext _context;

    public UsuarioService(DataContext context)
    {
        _context = context;
    }

    //obtener todos los usuarios
    public async Task<List<Usuario>> ObtenerUsuarios()
    {
        return await _context.Usuario.ToListAsync();
    }

    //obtener un usuario por id
    public async Task<Usuario?> ObtenerUsuarioPorId(Guid id)
    {
        return await _context.Usuario.FirstOrDefaultAsync(u => u.Id == id);
    }

    //crear un usuario 
    public async Task<Usuario> CrearUsuario(Usuario usuario)
    {
        usuario.Id = Guid.NewGuid();
        usuario.CreatedAt = DateTime.UtcNow;

        _context.Usuario.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }

    //actualizar un usuario
    public async Task<bool> ActualizarUsuario(Guid id, Usuario usuarioActualizado)
    {
        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null) return false;

        usuario.Nombre = usuarioActualizado.Nombre;
        usuario.Correo = usuarioActualizado.Correo;
        usuario.Contraseña = usuarioActualizado.Contraseña;

        await _context.SaveChangesAsync();
        return true;
    }

    //eliminar un usuario
    public async Task<bool> EliminarUsuario(Guid id)
    {
        var usuario = await _context.Usuario.FindAsync(id);
        if (usuario == null) return false;

        _context.Usuario.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
}