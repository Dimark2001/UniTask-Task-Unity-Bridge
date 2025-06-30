using System;
using System.Threading;

public abstract class AsyncOperationBase : IAsyncOperation, IDisposable
{
    protected readonly CancellationTokenSource _cts;
    protected Action _continuation;
    protected bool _completed;
    protected Exception _error;

    protected AsyncOperationBase()
    {
        _cts = new CancellationTokenSource();
    }

    public bool IsCompleted => _completed;

    public void OnCompleted(Action continuation)
    {
        if (IsCompleted) continuation();
        else _continuation = continuation;
    }

    public abstract void GetResult();

    public void Cancel()
    {
        _cts?.Cancel();
        Dispose();
    }

    public void Dispose()
    {
        _cts?.Dispose();
    }
}