namespace Lesson27.Services.Interfaces
{
    public interface IHasher
    {
        public string GetHash(string rawValue);
    }
}