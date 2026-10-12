class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;
    private int _completedCount;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int targetCount,
        int bonusPoints,
        int completedCount = 0,
        bool isComplete = false)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _completedCount = completedCount;
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (_completedCount >= _targetCount)
        {
            return 0;
        }

        _completedCount++;

        if (_completedCount >= _targetCount)
        {
            _isComplete = true;
            return _points + _bonusPoints;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _completedCount >= _targetCount || _isComplete;
    }

    public override string GetStatus()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_name}: {_description} (Completed {_completedCount}/{_targetCount} times)";
    }

    public override string GetSaveString()
    {
        return $"{GetTypeName()}|{_name}|{_description}|{_points}|{_targetCount}|{_bonusPoints}|{_completedCount}|{_isComplete}";
    }

    protected override string GetTypeName()
    {
        return "ChecklistGoal";
    }
}
