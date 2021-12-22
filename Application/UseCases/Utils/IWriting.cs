namespace Application.UseCases.Utils
{
    public interface IWriting<out TO, in TI>
    {
        TO Execute(TI dto);
        TO Execute(TI dto,int id);
    }
}