
using AutoMapper;

using Domain.Interfaces.Services;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

using Valid.PesquisaBiometrica.Application.InputModels;

namespace Valid.PesquisaBiometrica.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaCidadaoDigitalController : ControllerBase
    {
        private readonly ICidadaoService _cidadaoService;
        private IMapper _mapper;

        public PesquisaCidadaoDigitalController(IMapper mapper, ICidadaoService cidadaoService)
        {
            _mapper = mapper;
            _cidadaoService = cidadaoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetByFace([FromBody] CidadaoGetRequest request)
        {
            //\var result = await _cidadaoService.GetAsync();
            return Ok();
        }
    }
}
