using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using apiStarWarsProject;
using apiStarWarsProject.Services;
using apiStarWarsProject.DTOs;

namespace apiStarWarsProject.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class JediController: ControllerBase
    {
        private readonly JediService _jediService;

        public JediController(JediService jediService)
        {
            _jediService = jediService;
        }

        [HttpGet]
        [Route("List of Jedis")]
        public async Task<ActionResult<List<JediDTO>>> Get()
        {
            return Ok(await _jediService.GetJedi());
        }
        
      
        //Guardar un registro en la tabla
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Guardar(JediDTO jediDTO)
        {   
            var result = await _jediService.SaveJediData(jediDTO);
            return Ok(result);
        }

        //Editar un registro ya ingresado
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<JediDTO>> Editar(JediDTO jediDTO)
        {
           var result = await _jediService.UpdateJedi(jediDTO);
            return Ok(result);
        }

        
        [HttpDelete]
        [Route("Delete/{id}")]   
        public async Task<ActionResult<JediDTO>> Eliminar(int id)
        {
            var result = await _jediService.DeleteJediData(id);            
            return Ok(result);
        }  
    }
}