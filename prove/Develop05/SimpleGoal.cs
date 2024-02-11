class SimpleGoal : Goal
{
    private bool _isCompleted;
    public SimpleGoal(string shortName, string description, string points) : base(shortName, description, points)
    {
    }

    public override void RecordEvent()
    {
        if (!_isCompleted)
        {
            _isCompleted = true;
        }
    }
    public override bool IsCompleted()
    {
        return _isCompleted;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{_shortName},{_description},{_points},{(IsCompleted() ? "True" : "False")}";
    }

}