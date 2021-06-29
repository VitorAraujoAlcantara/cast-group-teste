using System;
namespace castgroup.models.Dtos
{
    public class CursoDto
    {
        public Guid CursoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int? QtdAlunos { get; set; }
        public string CategoriaDescricao { get; set; }
        public Guid Categoriaid { get; set; }
    }
}
