using System;
namespace castgroup.models
{
    public class Curso
    {
        public Guid CursoId { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int? QtdAlunos { get; set; }
        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
