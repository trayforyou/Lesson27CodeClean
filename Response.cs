namespace Lesson27
{
    public class Response : IResponse
    {
        private string _message;
        private bool _isConnected;

        public Response(bool isConnected, string message)
        {
            if(string.IsNullOrEmpty(message))
                throw new ArgumentNullException(nameof(message));

            _isConnected = isConnected;
            _message = message;
        }

        public string Message => _message;
        public bool IsConnected => _isConnected;
    }
}