namespace Api.Endpoints.V1.CreateUsuario
{
    public class CreateUsuarioRequest
    {
        public long Id { get; set; }

        public string? Nombre { get; set; }

        public string? Documento { get; set; }
    }
}
