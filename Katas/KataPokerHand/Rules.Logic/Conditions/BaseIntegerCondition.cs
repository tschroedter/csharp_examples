namespace Rules.Logic.Conditions
{
    public abstract class BaseIntegerCondition
    {
        public int Actual { get; set; }
        public int Threshold { get; set; }

        public abstract bool IsSatisfied();
    }
}