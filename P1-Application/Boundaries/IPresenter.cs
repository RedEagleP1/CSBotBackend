namespace P1_Application.Boundaries
{
    public interface IPresenter<T, TView> where T : IOutputPort
    {
        TView Present(T response);
    }

    public interface IOutputPort
    {
    }
}