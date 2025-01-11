using Api.Application.Contracts;
using Api.Domain;
using Api.Infrastructure;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Api.Application
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UniDatabaseContext _Context;

        public UsuarioRepository(UniDatabaseContext Context)
        {
            _Context = Context;
        }

        public async Task<Result<bool>> Login(Usuario usuario)
        {
            if (usuario == null)
            {
                return new Error("Usuario no Existe");
            }

            var UsuarioExists = await _Context.Usuarios.Where(x => x.Documento == usuario.Documento).AnyAsync();

            return Result.Ok(UsuarioExists);
        }

        public async Task<Result<bool>> Create(Usuario usuario)
        {
            if (usuario == null)
            {
                return new Error("No se envió ningún usuario");
            }

            await _Context.Usuarios.AddAsync(usuario);
            await _Context.SaveChangesAsync();

            await _Context.UsuarioRols.AddAsync(new UsuarioRol
            {
                IdRol = 1,
                IdUsuario = usuario.Id
            });

            await _Context.SaveChangesAsync();

            await _Context.Creditos.AddAsync(new Credito
            {
                IdUsuario = usuario.Id,
                Cantidad = 9
            });

            await _Context.SaveChangesAsync();

            return Result.Ok(true);
        }

        public async Task<Result<Usuario>> Get(string Documento)
        {
            var result = await _Context.Usuarios
                .Where(x => x.Documento == Documento)
                .Include(x => x.UsuarioRols)
                .ThenInclude(x => x.IdRolNavigation)
                .Include(x => x.Creditos)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                return new Error("Usuario no encontrado");
            }

            return Result.Ok(result);
        }

        public async Task<Result<bool>> Update(Usuario usuario)
        {
            await _Context.Usuarios
                    .Where(x => x.Id == usuario.Id)
                    .ExecuteUpdateAsync(x => 
                        x.SetProperty(u => u.Nombre, usuario.Nombre)
                        .SetProperty(u => u.Documento, usuario.Documento)
                    );

            await _Context.SaveChangesAsync();

            return Result.Ok(true);
        }

        public async Task<Result<bool>> Delete(int Id)
        {
            var UsuarioToDelete = await _Context.Usuarios.Where(x => x.Id == Id).FirstOrDefaultAsync();

            if (UsuarioToDelete == null)
            {
                return new Error("Usuario no Encontrado");
            }

            _Context.Usuarios.Remove(UsuarioToDelete);

            await _Context.SaveChangesAsync();

            return Result.Ok(true);
        }
    }
}
