using SafePilotBrothers.Model.Interfaces;
using SafePilotBrothers.Utilities;

namespace SafePilotBrothers.Model
{
    /// <summary>
    ///     Класс сейфа.
    /// </summary>
    public class Safe : ISafe
    {
        /// <summary>
        ///     Класс сейфа.
        /// </summary>
        /// <param name="configuration">Конфигурация приложения.</param>
        public Safe(IConfiguration configuration)
        {
            var size = configuration.GetValue<int>("SizeFields");

            Sticks = new Stick[size][];

            UtilitySafe.RandomSticks(Sticks);
        }

        /// <inheritdoc />
        public Stick[][] Sticks { get; set; }
    }
}