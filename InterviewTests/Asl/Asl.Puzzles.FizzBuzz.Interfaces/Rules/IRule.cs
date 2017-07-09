namespace Asl.Puzzles.FizzBuzz.Interfaces.Rules
{
    public interface IRule
    {
        int Priority { get; }
        bool CanApply(int number);
        string Apply(int number);
    }
}