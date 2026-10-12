using System;

class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isComplete;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string GetName() => _name;
    public string GetDescription() => _description;
    public int GetPoints() => _points;

    public virtual bool IsComplete() => _isComplete;

    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual string GetStatus()
    {
        return $"{(_isComplete ? "[X]" : "[ ]")} {_name}: {_description}";
    }

    protected virtual string GetTypeName()
    {
        return "Goal";
    }

    public virtual string GetSaveString()
    {
        return $"{GetTypeName()}|{_name}|{_description}|{_points}|{_isComplete}";
    }

    public static Goal CreateFromSaveString(string line)
    {
        string[] parts = line.Split('|');

        if (parts.Length < 5)
        {
            throw new FormatException("Invalid goal data format.");
        }

        string goalType = parts[0];

        switch (goalType)
        {
            case "SimpleGoal":
                if (parts.Length < 5)
                {
                    throw new FormatException("SimpleGoal data is incomplete.");
                }
                return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));

            case "EternalGoal":
                if (parts.Length < 6)
                {
                    throw new FormatException("EternalGoal data is incomplete.");
                }
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));

            case "ChecklistGoal":
                if (parts.Length < 8)
                {
                    throw new FormatException("ChecklistGoal data is incomplete.");
                }
                return new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6]),
                    bool.Parse(parts[7]));

            default:
                throw new FormatException($"Unsupported goal type: {goalType}");
        }
    }
}
