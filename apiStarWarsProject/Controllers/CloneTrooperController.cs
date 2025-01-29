using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

using apiStarWarsProject;
using apiStarWarsProject.Services;


namespace apiStarWarsProject.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CloneTrooperController: ControllerBase
    {
        private readonly CloneTrooperService _cloneTrooperService;

        public CloneTrooperController(CloneTrooperService cloneTrooperService)
        {
            _cloneTrooperService = cloneTrooperService;
        }

        [HttpGet]
        [Route("List of Troopers")]
        public async Task<ActionResult<List<CloneTrooperDTO>>> Get()
        {
            return Ok(await _cloneTrooperService.GetTrooper());
        }
        
      
        //Guardar un registro en la tabla
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Guardar(CloneTrooperDTO cloneTrooperDTO)
        {   
            var result = await _cloneTrooperService.SaveTrooperData(cloneTrooperDTO);
            return Ok(result);
        }

        //Editar un registro ya ingresado
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<CloneTrooperDTO>> Editar(CloneTrooperDTO cloneTrooperDTO)
        {
           var result = await _cloneTrooperService.UpdateTrooper(cloneTrooperDTO);
            return Ok(result);
        }

        
        [HttpDelete]
        [Route("Delete/{id}")]   
        public async Task<ActionResult<CloneTrooperDTO>> Eliminar(string id)
        {
            var result = await _cloneTrooperService.DeleteTrooperData(id);            
            return Ok(result);
        }  
    }
}