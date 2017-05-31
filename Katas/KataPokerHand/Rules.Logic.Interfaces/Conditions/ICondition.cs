namespace Rules.Logic.Interfaces.Conditions
{
    public interface ICondition
    {
        int Actual { get; set; }
        int Threshold { get; set; }
        bool IsSatisfied();
    }
}