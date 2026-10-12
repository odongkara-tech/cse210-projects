class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(string name, string description, int points, int timesCompleted = 0)
        : base(name, description, points)
    {
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        return _points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatus()
    {
        return $"[ ] {_name}: {_description} (Completed {_timesCompleted} times)";
    }

    public override string GetSaveString()
    {
        return $"{GetTypeName()}|{_name}|{_description}|{_points}|{_timesCompleted}";
    }

    protected override string GetTypeName()
    {
        return "EternalGoal";
    }
}
