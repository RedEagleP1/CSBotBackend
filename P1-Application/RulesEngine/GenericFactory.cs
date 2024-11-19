namespace P1_Application.RulesEngine
{
    public class RuleComponentFactory<T>
    {
        public T CreateFromRecord(T record)
        {

            return Activator.CreateInstance<T>();
        }

    }

    public interface IRuleComponentFactory<T>
    {
        T CreateFromRecord(T record);
    }
}