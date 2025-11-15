using Lesson27.Enums;

namespace Lesson27.Services
{
    public class Validator
    {
        private const string Space = " ";
        private const int MinSymbols = 10;

        public ValidationNumberStates TryValidate(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return ValidationNumberStates.Empty;

            value = value.Replace(Space, string.Empty);

            if (value.Length < MinSymbols)
                return ValidationNumberStates.IncorrectFormat;

            return ValidationNumberStates.Success;
        }
    }
}