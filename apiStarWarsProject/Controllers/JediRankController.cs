using apiStarWarsProject.DTOs;
using apiStarWarsProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiStarWarsProject{

    [Route("api/[Controller]")]
    [ApiController]
    public class JediRankController: ControllerBase
    {
        private readonly JediRankService _jediRankService;

        public JediRankController(JediRankService jediRankService)
        {
            _jediRankService = jediRankService;
        }

        [HttpGet]
        [Route("Jedi Ranks")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _jediRankService.GetJediRanks());
        }

        [HttpPost]
        [Route("Create Rank")]
        public async Task<ActionResult> Guardar(JediRankDTO jediRankDTO)
        {
            var _result = await _jediRankService.CreateJediRank(jediRankDTO);
            return Ok(_result);
        }
    }
}