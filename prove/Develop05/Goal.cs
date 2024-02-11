public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;

    public Goal(string shortName, string description, string points)
    {
        _shortName = shortName;
        _description = description;
        _points = points;
    }

    public string GetPoints()
    {
        return _points;
    }

    public abstract bool IsCompleted();

    public abstract void RecordEvent();

    public abstract string GetStringRepresentation();

    public virtual string GetDetailsString()
    {
        return $"[{(IsCompleted() ? 'X' : ' ')}] {_shortName} ({_description})";
    }

    public string GetName()
    {
        return _shortName;
    }

}