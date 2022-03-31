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
    public class AlquilerController : ControllerBase
    {
        private readonly IAlquilerRepository _alquilerRepository;
        private readonly IMapper _maper;
        public AlquilerController(IAlquilerRepository alquilerRepository, IMapper mapper)
        {
            _alquilerRepository = alquilerRepository;
            _maper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAlquilers()
        {
            var alquiler = await _alquilerRepository.GetAlquilers();
            var alquilerdto = _maper.Map<IEnumerable<AlquilerDtos>>(alquiler);
            return Ok(alquilerdto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Getalquiler(int id)
        {
            var alquiler = await _alquilerRepository.GetAlquiler(id);
            var alquilerdto = _maper.Map<AlquilerDtos>(alquiler);
            return Ok(alquilerdto);
        }
        [HttpPost]
        public async Task<IActionResult> Postalquiler(AlquilerDtos alquilerDtos)
        {
            var alquiler = _maper.Map<Alquiler>(alquilerDtos);
            await _alquilerRepository.InsertAlquiler(alquiler);
            return Ok(alquilerDtos);
        }
        [HttpPut]
        public async Task<IActionResult> Putalquiler(int id, AlquilerDtos alquiler)
        {
            var alquilerdto = _maper.Map<Alquiler>(alquiler);
            alquilerdto.IdAlquiler = id;
            var Update = await _alquilerRepository.Updatealquiler(alquilerdto);
            var updatealquiler = new ApiResponse<bool>(Update);
            return Ok(updatealquiler);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletealquiler(int id)
        {

            var result = await _alquilerRepository.DeleteAlquiler(id);
            var deletealquiler = new ApiResponse<bool>(result);
            return Ok(deletealquiler);
        }
    }
}

