using Lesson27.UIElements.Interfaces;

namespace Lesson27.Views
{
    public class Menu : IUserInterfaceView
    {
        private readonly IMessageBox _messageBox;
        private readonly ITextBox _textBox;
        private readonly IButton _button;

        public event Action ButtonClicked;

        public Menu(ITextBox textBox, IButton button, IMessageBox messageBox)
        {
            _textBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
            _button = button ?? throw new ArgumentNullException(nameof(button));
            _messageBox = messageBox ?? throw new ArgumentNullException(nameof(messageBox));

            button.ButtonClicked += () => ButtonClicked?.Invoke();
        }

        public string UserInput => _textBox.Text;

        public void SetMessage(string message) =>
            _messageBox.Message = string.IsNullOrWhiteSpace(message) ? throw new ArgumentException("Сообщение пустое") : message;
    }
}