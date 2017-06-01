namespace Rules.Logic.Conditions
{
    public abstract class BaseCondition <T>
    {
        public T Actual { get; set; }
        public T Threshold { get; set; }

        public abstract bool IsSatisfied();
    }
}