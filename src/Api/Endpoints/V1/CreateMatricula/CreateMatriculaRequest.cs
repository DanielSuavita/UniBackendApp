using Api.Domain;

namespace Api.Endpoints.V1.CreateMatricula
{
    public class CreateMatriculaRequest
    {
        public long Id { get; set; }
        public int? CreditosInscritos { get; set; }
        public long IdEstudiante { get; set; }
        public long IdPeriodoAcademico { get; set; }
        public virtual ICollection<AsignaturasMatriculaRequest> AsignaturasMatriculas { get; set; } = new List<AsignaturasMatriculaRequest>();
    }

    public class AsignaturasMatriculaRequest
    {
        public long Id { get; set; }

        public long IdAsignatura { get; set; }

        public long IdMatricula { get; set; }

        public long IdProfesor { get; set; }
    }

}
