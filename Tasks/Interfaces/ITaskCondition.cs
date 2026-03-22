using MergeGrid.Runtime.Tasks.Core;

namespace MergeGrid.Runtime.Tasks.Interfaces
{
    public interface ITaskCondition
    {
        bool IsMet(TaskProgress progress);
    }
}
