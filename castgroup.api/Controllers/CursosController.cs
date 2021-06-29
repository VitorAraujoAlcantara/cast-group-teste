using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using castgroup.models;
using castgroup.models.Dtos;
using castgroup.services.interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace castgroup.api.Controllers
{
    /// <summary>
    /// Domínio curso
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CursosController : Controller
    {
        private readonly ICursoService service;
        private readonly IMapper mapper;

        public CursosController(ICursoService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        /// <summary>
        /// Insere novo registro
        /// </summary>
        /// <param name="curso"></param>
        /// <returns></returns>
        [HttpPost]
        public Task Post([FromBody] CursoInsertDto curso)
        {
            return service.Insert(mapper.Map<Curso>(curso));
        }

        /// <summary>
        /// Atualiza um registro existente
        /// </summary>
        /// <param name="curso"></param>
        /// <returns></returns>
        [HttpPut]
        public Task Put([FromBody] CursoUpdateDto curso)
        {
            return service.Update(mapper.Map<Curso>(curso));
        }

        /// <summary>
        /// Remove um registro existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public Task Delete(Guid id)
        {
            return service.Delete(id);
        }

        /// <summary>
        /// Obtem um curso pelo seu ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<CursoDto> Get(Guid id)
        {
            return mapper.Map<CursoDto>(await service.Get(id));
        }

        /// <summary>
        /// Retorna a lista dos cursos 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public  async Task<IEnumerable<CursoDto>> All()
        {
            return mapper.Map<IEnumerable<CursoDto>>( await service.All());
        }
    }
}
