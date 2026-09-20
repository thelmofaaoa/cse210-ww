public class EternalGoal : Goal
{
    private int _timesCompleted;

    public EternalGoal(
        string shortName,
        string description,
        int points)
        : base(shortName, description, points)
    {
        _timesCompleted = 0;
    }

    public EternalGoal(
        string shortName,
        string description,
        int points,
        int timesCompleted)
        : base(shortName, description, points)
    {
        _timesCompleted = timesCompleted;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[ ] {GetShortName()} ({GetDescription()}) - Completed {_timesCompleted} times";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{GetShortName()}|{GetDescription()}|{GetPoints()}|{_timesCompleted}";
    }
}