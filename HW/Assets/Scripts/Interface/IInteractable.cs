namespace Interface
{
    public interface IInteractable : IAction
    {
        bool IsInteractable { get; }
    }
}