namespace P1_Application.Services.RulesEngine
{
    public interface IResult<T>
    {
        T Execute();
    }
}