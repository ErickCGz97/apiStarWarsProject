using apiStarWarsProject.DTOs;
using apiStarWarsProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiStarWarsProject{

    [Route("api/[Controller]")]
    [ApiController]
    public class TrooperRankController: ControllerBase
    {
        private readonly TrooperRankService _trooperRankService;

        public TrooperRankController(TrooperRankService trooperRankService)
        {
            _trooperRankService = trooperRankService;
        }

        [HttpGet]
        [Route("Trooper Ranks")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _trooperRankService.GetTrooperRanks());
        }

        [HttpPost]
        [Route("Create Rank")]
        public async Task<ActionResult> Guardar(TrooperRankDTO trooperRankDTO)
        {
            var _result = await _trooperRankService.CreateTrooperRank(trooperRankDTO);
            return Ok(_result);
        }
    }
}