namespace Api.Endpoints.V1.GetEstudiantesMatriculadosByAsignatura
{
    public class GetEstudiantesMatriculadosByAsignaturaRequest
    {
        public long Id { get; set; }

        public long IdAsignatura { get; set; }

        public long IdMatricula { get; set; }

        public long IdProfesor { get; set; }
    }
}
