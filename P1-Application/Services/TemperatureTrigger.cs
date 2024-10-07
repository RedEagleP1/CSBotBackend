public class TemperatureTrigger : ITrigger<WeatherEvent>
{
    private readonly double _threshold;

    public TemperatureTrigger(double threshold)
    {
        _threshold = threshold;
    }

    public bool Check(WeatherEvent @event) => @event.Temperature > _threshold;
}
