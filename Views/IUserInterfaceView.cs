namespace Lesson27.Views
{
    public interface IUserInterfaceView : IMessager
    {
        public event Action ButtonClicked;

        public string UserInput { get; }
    }
}