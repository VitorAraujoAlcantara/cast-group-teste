using AutoMapper;
using castgroup.models;
using castgroup.models.Dtos;

namespace castgroup.mappers
{
    internal class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CursoInsertDto, Curso>();
            CreateMap<CursoUpdateDto, Curso>();
            CreateMap<Curso, CursoDto>();
            CreateMap<Categoria, CategoriaDto>();
        }
    }
}
