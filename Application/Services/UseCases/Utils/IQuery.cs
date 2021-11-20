namespace Application.Services.UseCases.Utils
{
    public interface IQuery<out TO>
    {
        TO Execute();
        TO Execute(int id);
    }
}