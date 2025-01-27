using apiStarWarsProject.DTOs;
using apiStarWarsProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiStarWarsProject{

    [Route("api/[Controller]")]
    [ApiController]
    public class TrooperStatusController: ControllerBase
    {
        private readonly TrooperStatusService _trooperStatusService;

        public TrooperStatusController(TrooperStatusService trooperStatusService)
        {
            _trooperStatusService = trooperStatusService;
        }

        [HttpGet]
        [Route("Trooper Status")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _trooperStatusService.GetTrooperStatus());
        }

        [HttpPost]
        [Route("Create Status")]
        public async Task<ActionResult> Save(TrooperStatusDTO trooperStatusDTO)
        {
            var _result = await _trooperStatusService.CreateTrooperStatus(trooperStatusDTO);
            return Ok(_result);
        }
    }
}