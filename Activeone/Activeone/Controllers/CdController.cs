using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Activeone.Core.DTOs;
using Activeone.Core.Entities;
using Activeone.Core.Interfaces;
using Activeone.Infrastructure.Repositories;
using Activeone.Response;

namespace Activeone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CdController : ControllerBase
    {
        private readonly ICdRepository _cdRepository;
        private readonly IMapper _maper;
        public CdController(ICdRepository cdRepository, IMapper mapper)
        {
            _cdRepository = cdRepository;
            _maper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetClientes()
        {
            var cd = await _cdRepository.GetCds();
            var cddto = _maper.Map<IEnumerable<CdDtos>>(cd);
            return Ok(cddto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCliente(int id)
        {
            var cliente = await _cdRepository.GetCd(id);
            var clientedto = _maper.Map<CdDtos>(cliente);
            return Ok(clientedto);
        }
        [HttpPost]
        public async Task<IActionResult> PostCliente(CdDtos cddto)
        {
            var cd = _maper.Map<Cd>(cddto);
            await _cdRepository.InsertCD(cd);
            return Ok(cddto);
        }
        [HttpPut]
        public async Task<IActionResult> PutCliente(int id, CdDtos cddto)
        {
            var cddtos = _maper.Map<Cd>(cddto);
            cddtos.IdCd = id;
            var Update = await _cdRepository.UpdateCd(cddtos);
            var updatedto = new ApiResponse<bool>(Update);
            return Ok(updatedto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {

            var result = await _cdRepository.DeleteCd(id);
            var deletecd = new ApiResponse<bool>(result);
            return Ok(deletecd);
        }
    }
}
