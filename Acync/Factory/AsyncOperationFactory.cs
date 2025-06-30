using System;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

/// <summary>
/// Factory for creating platform-specific asynchronous operations (Task or UniTask).
/// </summary>
public static class AsyncOperationFactory
{
    /// <summary>
    /// Creates an asynchronous operation from a Task-based factory method.
    /// </summary>
    /// <param name="taskFactory">Factory method returning a Task.</param>
    /// <exception cref="PlatformNotSupportedException">Thrown in WebGL builds.</exception>
    public static IAsyncOperation Create(Func<CancellationToken, Task> taskFactory)
    {
#if UNITY_WEBGL
        throw new PlatformNotSupportedException("Task not supported in WebGL. Use UniTask instead.");
#else
        return new TaskAsyncOperation(taskFactory);
#endif
    }

#if UNITASK_AVAILABLE
    /// <summary>
    /// Creates an asynchronous operation from a UniTask-based factory method.
    /// </summary>
    /// <param name="taskFactory">Factory method returning a UniTask.</param>
    public static IAsyncOperation Create(Func<CancellationToken, UniTask> taskFactory)
    {
        return new UniTaskAsyncOperation(taskFactory);
    }
#else
    /// <summary>
    /// Throws an exception if UniTask is not available.
    /// </summary>
    /// <exception cref="InvalidOperationException">Always thrown when UniTask is missing.</exception>
    public static IAsyncOperation Create(Func<CancellationToken, UniTask> taskFactory)
    {
        throw new InvalidOperationException("UniTask not available. Add UniTask package first.");
    }
#endif
}