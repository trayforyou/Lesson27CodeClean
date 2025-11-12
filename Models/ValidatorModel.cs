using Lesson27.Models.Interfaces;

namespace Lesson27.Models
{
    public class ValidatorModel : IValidatorModel, IResultator
    {
        private const string ReasonEmpty = "Введите серию и номер паспорта";
        private const string ReasonIncorrectFormat = "Неверный формат серии или номера паспорта";
        private const string Space = " ";
        private const int MinSybols = 10;

        public event Action<string> Unverified;
        public event Action<IPassport> ResultReady;

        public void Validate(string value)
        {
            if (VerifyOnEmpty(value) == false)
                return;

            value = value.Replace(Space, string.Empty);

            if (VerifyOnCount(value) == false)
                return;

            ResultReady?.Invoke(new Passport(value));
        }

        private bool VerifyOnCount(string value)
        {
            if (value.Length >= MinSybols)
                return true;

            Unverified?.Invoke(ReasonIncorrectFormat);
            return false;
        }

        private bool VerifyOnEmpty(string value)
        {
            if (string.IsNullOrEmpty(value) == false)
                return true;

            Unverified?.Invoke(ReasonEmpty);
            return false;
        }
    }
}