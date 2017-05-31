namespace Rules.Logic.Interfaces.Rules
{
    public interface IRule <T>
    {
        int Priority { get; }
        T Apply(T info);
        void ClearConditions();
        void Initialize(T info);
        bool IsValid();
    }
}