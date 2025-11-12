using Lesson27.UIElements.Interfaces;

namespace Lesson27.UIElements
{
    public class Button : IButton
    {
        public event Action ButtonClicked;

        public void Click() =>
            ButtonClicked?.Invoke();
    }
}