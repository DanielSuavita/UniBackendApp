namespace Api.Endpoints.V1.PutUsuario
{
    public class PutUsuarioRequest
    {
        public long Id { get; set; }

        public string? Nombre { get; set; }

        public string? Documento { get; set; }
    }
}
