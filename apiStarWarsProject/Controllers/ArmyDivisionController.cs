using apiStarWarsProject.DTOs;
using apiStarWarsProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiStarWarsProject{

    [Route("api/[Controller]")]
    [ApiController]
    public class ArmyDivisionController: ControllerBase
    {
        private readonly ArmyDivisionService _armyDivisionService;

        public ArmyDivisionController(ArmyDivisionService armyDivisionService)
        {
            _armyDivisionService = armyDivisionService;
        }

        [HttpGet]
        [Route("Army Struct Divisions")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _armyDivisionService.GetDivisions());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Guardar(ArmyDivisionDTO armyDivisionDTO)
        {
            var _result = await _armyDivisionService.CreateArmyDivision(armyDivisionDTO);
            return Ok(_result);
        }
    }
}