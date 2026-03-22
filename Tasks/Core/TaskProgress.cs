using System.Collections.Generic;

namespace MergeGrid.Runtime.Tasks.Core
{
    public class TaskProgress
    {
        private readonly Dictionary<string, int> _progressMap = new();

        public void SetProgress(string key, int value)
        {
            _progressMap[key] = value;
        }

        public int GetProgress(string key)
        {
            return _progressMap.TryGetValue(key, out var val) ? val : 0;
        }

        public void Increment(string key, int amount = 1)
        {
            if (!_progressMap.ContainsKey(key))
                _progressMap[key] = 0;

            _progressMap[key] += amount;
        }
    }
}
