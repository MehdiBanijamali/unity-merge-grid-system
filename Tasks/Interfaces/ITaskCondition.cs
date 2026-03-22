using MergeGrid.Tasks.Core;

namespace MergeGrid.Tasks.Interfaces
{
    public interface ITaskCondition
    {
        bool IsMet(TaskProgress progress);
    }
}
