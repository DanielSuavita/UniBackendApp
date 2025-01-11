using Api.Domain;
using FluentResults;

namespace Api.Application.Contracts
{
    public interface IUsuarioRepository
    {
        Task<Result<bool>> Login(Usuario usuario);
        Task<Result<bool>> Create(Usuario usuario);
        Task<Result<bool>> Delete(int Id);
        Task<Result<Usuario>> Get(string Documento);
        Task<Result<bool>> Update(Usuario usuario);
    }
}