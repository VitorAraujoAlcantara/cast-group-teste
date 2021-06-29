using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using castgroup.models.Dtos;
using castgroup.services.interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace castgroup.api.Controllers
{
    [ApiController] 
    [Route("api/[controller]")]
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService service;
        private readonly IMapper mapper;

        public CategoriasController(ICategoriaService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        // GET: api/values
        [HttpGet]
        public async Task<IEnumerable<CategoriaDto>> Get()
        {
            return mapper.Map<IEnumerable<CategoriaDto>>( await service.All());
        }

        
    }
}
