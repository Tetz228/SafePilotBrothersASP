using SafePilotBrothers.Model;
using SafePilotBrothers.Services.Interfaces;

namespace SafePilotBrothers.Services
{
    /// <summary>
    ///     Сервисы для взаимодействия с рукоятками.
    /// </summary>
    public class StickService : IStickService
    {
        /// <inheritdoc />
        public Stick[][] TurnSticks(int indexColumn, int indexLine, Stick[][] sticks)
        {
            for (var i = 0; i < sticks.Length; i++)
            {
                sticks[indexLine][i].Position = sticks[indexLine][i].Position == Position.Horizontal ? Position.Vertical : Position.Horizontal;

                if (sticks[i][indexColumn] == sticks[indexLine][indexColumn])
                {
                    continue;
                }
     
                sticks[i][indexColumn].Position = sticks[i][indexColumn].Position == Position.Horizontal ? Position.Vertical : Position.Horizontal;
            }
            
            return sticks;
        }
        
        /// <inheritdoc />
        public bool IsCheckSticks(Stick[][] sticks)
        {
            int countHorizontal = 0;
            int countVertical = 0;

            for (var i = 0; i < sticks.Length; i++)
            {
                for (var j = 0; j < sticks.Length; j++)
                {
                    if (sticks[i][j].Position == Position.Horizontal)
                    {
                        countHorizontal++;
                    }
                    else
                    {
                        countVertical++;
                    }
                }
            }

            int countSticks = sticks.Length * sticks.Length;
            
            return countHorizontal == countSticks || countHorizontal == countSticks;
        }
    }
}