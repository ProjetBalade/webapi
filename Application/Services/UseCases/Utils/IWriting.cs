namespace Application.Services.UseCases.Utils
{
    public interface IWriting<out TO, in TI>
    {
        TO Execute(TI dto);
    }
}