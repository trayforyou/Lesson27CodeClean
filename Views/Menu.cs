using Lesson27.Presenters;

namespace Lesson27.Views
{
    public class Menu : IMessager
    {
        private readonly MessageBox _messageBox;
        private readonly TextBox _textBox;
        private readonly Presenter _presenter;

        public Menu(TextBox textBox, MessageBox messageBox, Presenter presenter)
        {
            _textBox = textBox ?? throw new ArgumentNullException(nameof(textBox));
            _messageBox = messageBox ?? throw new ArgumentNullException(nameof(messageBox));
            _presenter = presenter ?? throw new ArgumentNullException(nameof(_presenter));
        }

        public void ButtonClick()
        {
            _presenter.Handle(_textBox.Input);
        }

        public void SetMessage(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            _messageBox.Set(message);
        }
    }
}