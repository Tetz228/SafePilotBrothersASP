using Microsoft.AspNetCore.Mvc;
using SafePilotBrothers.Model;
using SafePilotBrothers.Model.Interfaces;
using SafePilotBrothers.Services.Interfaces;

namespace SafePilotBrothers.Controllers
{
    /// <summary>
    ///     Контроллер для взаимодействия с рукоятками.
    /// </summary>
    [Route("api/v1/")]
    [ApiController]
    public class StickController : ControllerBase
    {
        /// <summary>
        ///     Интерфейс сейфа.
        /// </summary>
        private readonly ISafe _safe;

        /// <summary>
        ///     Сервисы для взаимодействия с рукоятками.
        /// </summary>
        private readonly IStickService _stickService;

        /// <summary>
        ///     Контроллер для взаимодействия с рукоятками.
        /// </summary>
        public StickController(IStickService stickService, ISafe safe)
        {
            _stickService = stickService;
            _safe = safe;
        }

        /// <summary>
        ///     Повернуть рукоятки.
        /// </summary>
        /// <param name="sticks">Рукоятки.</param>
        /// <returns>Повернутые рукоятки.</returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Stick[][]> TurnSticks(Stick[][] sticks)
        {
            return Ok(_stickService.TurnSticks(sticks));
        }

        /// <summary>
        ///     Получить рукоятки.
        /// </summary>
        /// <returns>Рукоятки.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Stick[][]> GetSticks()
        {
            return Ok(_safe.Sticks);
        }
    }
}