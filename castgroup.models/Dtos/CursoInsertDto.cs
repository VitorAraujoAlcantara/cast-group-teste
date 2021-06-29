using System;
namespace castgroup.models.Dtos
{
    public class CursoInsertDto
    {
        public CursoInsertDto()
        {
        }

        public DateTime DataInicio { get; set; }
        public string Descricao { get; set; }
        public DateTime DataTermino { get; set; }
        public Guid CategoriaId { get; set; }
        public int? QtdAlunos { get; set; }
    }
}
