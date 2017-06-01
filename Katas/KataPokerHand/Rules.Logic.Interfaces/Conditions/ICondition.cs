namespace Rules.Logic.Interfaces.Conditions
{
    public interface ICondition <T>
    {
        T Actual { get; set; }
        T Threshold { get; set; }
        bool IsSatisfied();
    }
}