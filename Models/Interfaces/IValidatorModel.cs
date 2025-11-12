namespace Lesson27.Models.Interfaces
{
    public interface IValidatorModel
    {
        public event Action<string> Unverified;

        public void Validate(string value);
    }
}