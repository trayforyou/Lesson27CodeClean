namespace Lesson27.Models.Interfaces
{
    public interface IResultator
    {
        public event Action<IPassport> ResultReady;
    }
}