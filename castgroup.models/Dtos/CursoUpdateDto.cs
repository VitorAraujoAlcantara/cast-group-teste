using System;
namespace castgroup.models.Dtos
{
    public class CursoUpdateDto
    {
        public Guid CursoId { get; set; }
        public string Descricao { get; set; }
        public Guid CategoriaId { get; set; }
        public int? QtdAlunos { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
