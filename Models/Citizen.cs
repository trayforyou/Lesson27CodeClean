using Lesson27.Enums;

namespace Lesson27.Models
{
    public class Citizen
    {
        public Citizen(CitizenStates state)
        {
            State = state;
        }

        public CitizenStates State { get; }
    }
}