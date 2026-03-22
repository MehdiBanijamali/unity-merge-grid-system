using MergeGrid.Tasks.Data;

namespace MergeGrid.Tasks.Core
{
    public class Task
    {
        public TaskDefinition Definition { get; }
        public TaskState State { get; private set; }

        private readonly TaskProgress _progress;

        public Task(TaskDefinition definition)
        {
            Definition = definition;
            _progress = new TaskProgress();
            State = TaskState.Locked;
        }

        public void Activate()
        {
            if (State == TaskState.Locked)
                State = TaskState.Active;
        }

        public void UpdateProgress(string key, int amount = 1)
        {
            if (State != TaskState.Active)
                return;

            _progress.Increment(key, amount);
        }

        public bool EvaluateCompletion()
        {
            if (State != TaskState.Active)
                return false;

            foreach (var condition in Definition.Conditions)
            {
                if (!condition.IsMet(_progress))
                    return false;
            }

            State = TaskState.Completed;
            return true;
        }

        public void Claim()
        {
            if (State != TaskState.Completed)
                return;

            foreach (var reward in Definition.Rewards)
                reward.Apply();

            State = TaskState.Claimed;
        }
    }
}
