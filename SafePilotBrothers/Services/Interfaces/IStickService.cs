using SafePilotBrothers.Model;

namespace SafePilotBrothers.Services.Interfaces
{
    /// <summary>
    ///     Интерфейс взаимодействия с рукоятками.
    /// </summary>
    public interface IStickService
    {
        /// <summary>
        ///     Повернуть рукоятки.
        /// </summary>
        /// <param name="sticks">Рукоятки.</param>
        /// <returns>Повернутые рукоятки.</returns>
        public Stick[][] TurnSticks(Stick[][] sticks);
    }
}