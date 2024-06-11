using DevoraLime.BattleGame.Services;
using Microsoft.AspNetCore.Mvc;

namespace DevoraLime.BattleGame.WebAPI.Controllers
{
    [ApiController]
    [Route("api/battle-game")]
    public class BattleGameController : ControllerBase
    {
        private readonly IBattleGameService _battleGameService;

        public BattleGameController(
            IBattleGameService battleGameService)
        {
            _battleGameService = battleGameService;
        }


        [HttpPost("generate")]
        public ActionResult<int> GenerateHeroes(
            [FromBody] int heroCount)
        {
            var arenaId = _battleGameService
                .GenerateHeroes(heroCount);

            return Ok(arenaId);
        }

        [HttpGet("battle/{arenaId}")]
        public ActionResult<List<string>> Battle(
            int arenaId)
        {
            var history = _battleGameService
                .GetBattleHistory(arenaId);

            if (history == null)
            {
                return NotFound("Arena not found.");
            }

            return Ok(history);
        }
    }
}
