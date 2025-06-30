using System;
using System.Threading;
using Cysharp.Threading.Tasks;

#if UNITASK_AVAILABLE
public class UniTaskAsyncOperation : AsyncOperationBase
{
    private readonly UniTask _task;

    public UniTaskAsyncOperation(Func<CancellationToken, UniTask> taskFactory) : base()
    {
        _task = taskFactory(_cts.Token);

        if (_task.Status.IsCompleted())
        {
            _completed = true;
            CaptureExceptionIfAny();
            return;
        }

        _task.GetAwaiter().OnCompleted(() =>
        {
            _completed = true;
            CaptureExceptionIfAny();
            _continuation?.Invoke();
        });
    }

    private void CaptureExceptionIfAny()
    {
        try { _task.GetAwaiter().GetResult(); }
        catch (Exception ex) { _error = ex; }
    }

    public override void GetResult()
    {
        if (_error != null) throw _error;
        _task.GetAwaiter().GetResult();
    }
}
#endif