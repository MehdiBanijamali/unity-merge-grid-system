namespace MergeGrid.Runtime.Interfaces
{
    public interface IMergeable
    {
        int Level { get; }
        bool CanMerge(IMergeable other);
        IMergeable Merge(IMergeable other);
    }
}
