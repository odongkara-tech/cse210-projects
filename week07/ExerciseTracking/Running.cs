using System;

class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;
    public override double GetSpeed() => _distance / GetMinutes() * 60;
    public override double GetPace() => GetMinutes() / _distance;

    public override string GetSummary()
    {
        return $"{GetDate():dd MMM yyyy} Running ({GetMinutes()} min)- Distance {_distance:0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
