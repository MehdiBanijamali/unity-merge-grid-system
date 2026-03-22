using System.Collections.Generic;
using MergeGrid.Runtime.Tasks.Core;
using MergeGrid.Runtime.Tasks.Data;

namespace MergeGrid.Runtime.Tasks.Systems
{
    public class TaskSystem
    {
        private readonly Dictionary<string, Task> _tasks = new();
        private readonly TaskEvaluator _evaluator = new();

        public void AddTask(TaskDefinition definition)
        {
            if (_tasks.ContainsKey(definition.Id))
                return;

            var task = new Task(definition);
            _tasks[definition.Id] = task;
        }

        public void ActivateTask(string id)
        {
            if (_tasks.TryGetValue(id, out var task))
                task.Activate();
        }

        public void ReportProgress(string key, int amount = 1)
        {
            foreach (var task in _tasks.Values)
            {
                if (task.State == TaskState.Active)
                {
                    task.UpdateProgress(key, amount);
                }
            }

            _evaluator.EvaluateAll(new List<Task>(_tasks.Values));
        }

        public Task GetTask(string id)
        {
            return _tasks.TryGetValue(id, out var task) ? task : null;
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _tasks.Values;
        }
    }
}
