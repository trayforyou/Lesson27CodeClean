namespace Lesson27
{
    public interface IResponse
    {
        public string Message { get; }
        public bool IsConnected { get; }
    }
}