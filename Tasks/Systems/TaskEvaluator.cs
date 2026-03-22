using System.Collections.Generic;
using MergeGrid.Runtime.Tasks.Core;

namespace MergeGrid.Runtime.Tasks.Systems
{
    public class TaskEvaluator
    {
        public void EvaluateAll(List<Task> tasks)
        {
            foreach (var task in tasks)
            {
                if (task.State == TaskState.Active)
                {
                    task.EvaluateCompletion();
                }
            }
        }
    }
}
