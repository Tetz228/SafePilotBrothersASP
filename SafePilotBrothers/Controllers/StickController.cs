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
        /// <param name="indexColumn">Индекс изменяемого столбца.</param>
        /// <param name="indexLine">Индекс изменяемой строки.</param>
        /// <param name="sticks">Рукоятки.</param>
        /// <returns>Повернутые рукоятки.</returns>
        [HttpPut("TurnSticks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Stick[][]> TurnSticks(int indexColumn, int indexLine, Stick[][] sticks)
        {
            return Ok(_stickService.TurnSticks(indexColumn, indexLine, sticks));
        }
        
        /// <summary>
        ///     Проверка всех рукояток на совпадения положения.
        /// </summary>
        /// <returns>Результат о положении рукояток.</returns>
        [HttpGet("IsCheckSticks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<bool> IsCheckSticks()
        {
            if (_stickService.IsCheckSticks(_safe.Sticks))
            {
                return Ok();
            }
            
            return NoContent();
        }
        
        /// <summary>
        ///     Получить рукоятки.
        /// </summary>
        /// <returns>Рукоятки.</returns>
        [HttpGet("GetSticks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<Stick[][]> GetSticks()
        {
            return Ok(_safe.Sticks);
        }
    }
}