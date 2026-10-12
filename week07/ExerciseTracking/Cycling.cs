using System;

class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance() => _speed * GetMinutes() / 60;
    public override double GetSpeed() => _speed;
    public override double GetPace() => 60 / _speed;

    public override string GetSummary()
    {
        return $"{GetDate():dd MMM yyyy} Cycling ({GetMinutes()} min)- Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
