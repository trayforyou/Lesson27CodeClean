namespace Lesson27.Models.Interfaces
{
    public interface IDataBaseHandler
    {
        public IResponse Handle(IPassport passport);
    }
}