namespace Lesson27.Models.Interfaces
{
    public class Passport : IPassport
    {
        private readonly string _number;

        public Passport(string number)
        {
            _number = string.IsNullOrWhiteSpace(number) ? throw new ArgumentNullException(nameof(number)) : number;
        }

        public string Number => _number;
    }
}