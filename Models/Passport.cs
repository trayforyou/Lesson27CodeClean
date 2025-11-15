namespace Lesson27.Models
{
    public class Passport
    {
        public Passport(string number)
        {
            Number = string.IsNullOrWhiteSpace(number) ? throw new ArgumentNullException(nameof(number)) : number;
        }

        public string Number { get; }
    }
}