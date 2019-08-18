using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Apteka.Utils
{
    public class CTask
    {
        public static void StartAndWaitAllThrottled(IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, CancellationToken cancellationToken = new CancellationToken())
        {
            StartAndWaitAllThrottled(tasksToRun, maxTasksToRunInParallel, -1, cancellationToken);
        }

        public static void StartAndWaitAllThrottled(IEnumerable<Task> tasksToRun, int maxTasksToRunInParallel, int timeoutInMilliseconds, CancellationToken cancellationToken = new CancellationToken())
        {
            var tasks = tasksToRun.ToList();

            using (var throttler = new SemaphoreSlim(maxTasksToRunInParallel))
            {
                var postTaskTasks = new List<Task>();
                tasks.ForEach(t => postTaskTasks.Add(t.ContinueWith(tsk => throttler.Release(), cancellationToken)));
                foreach (var task in tasks)
                {
                    throttler.Wait(timeoutInMilliseconds, cancellationToken);
                    cancellationToken.ThrowIfCancellationRequested();
                    task.Start();
                }

                Task.WaitAll(postTaskTasks.ToArray(), cancellationToken);
            }
        }
    }
}
