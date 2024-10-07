
// Example trigger and response implementations
public class RainTrigger : ITrigger<WeatherEvent>
{
    public bool Check(WeatherEvent @event) => @event.IsRaining;
}
