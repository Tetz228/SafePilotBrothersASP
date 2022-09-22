using SafePilotBrothers.Model;

namespace SafePilotBrothers.Utilities
{
    /// <summary>
    ///     Класс утилиты для сейфа.
    /// </summary>
    public static class UtilitySafe
    {
        /// <summary>
        ///     Заполнение сейфа рукоятками.
        /// </summary>
        /// <param name="sticks">Рукоятки.</param>
        public static void RandomSticks(Stick[][] sticks)
        {
            var random = new Random();
            
            for (int i = 0; i < sticks.Length; i++)
            {
                sticks[i] = new Stick[] { new() };
                
                for (int j = 0; j < sticks[i].Length; j++)
                {
                    sticks[i][j].Position = (Position)random.Next(0, 2);
                }
            }
            
        }
    }
}