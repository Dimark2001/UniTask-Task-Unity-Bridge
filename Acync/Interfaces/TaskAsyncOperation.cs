using System;
using System.Threading;
using System.Threading.Tasks;

#if !UNITY_WEBGL
public class TaskAsyncOperation : AsyncOperationBase
{
    private readonly Task _task;

    public TaskAsyncOperation(Func<CancellationToken, Task> taskFactory)
    {
        _task = taskFactory(_cts.Token);

        if (_task.IsCompleted)
        {
            _completed = true;
            CaptureExceptionIfAny();
            return;
        }

        _task.ContinueWith(_ =>
        {
            _completed = true;
            CaptureExceptionIfAny();
            _continuation?.Invoke();
        }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private void CaptureExceptionIfAny()
    {
        if (_task.IsFaulted)
        {
            _error = _task.Exception?.InnerException ?? _task.Exception;
        }
        else if (_task.IsCanceled)
        {
            _error = new TaskCanceledException(_task);
        }
    }

    public override void GetResult()
    {
        if (_error != null) throw _error;
        _task.GetAwaiter().GetResult();
    }
}
#endif