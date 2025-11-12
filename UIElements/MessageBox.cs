using Lesson27.UIElements.Interfaces;

namespace Lesson27.UIElements
{
    public class MessageBox : IMessageBox
    {
        public string Message { set => throw new NotImplementedException(); }
    }
}