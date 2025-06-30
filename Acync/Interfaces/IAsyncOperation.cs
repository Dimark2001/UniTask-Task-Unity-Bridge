using System;

/// <summary>
/// Represents an asynchronous operation that can be awaited, canceled, and checked for completion.
/// </summary>
public interface IAsyncOperation
{
    /// <summary>Gets whether the operation has completed.</summary>
    bool IsCompleted { get; }

    /// <summary>Registers a continuation to execute when the operation completes.</summary>
    /// <param name="continuation">The action to invoke upon completion.</param>
    void OnCompleted(Action continuation);

    /// <summary>Gets the result of the operation or throws an exception if it failed.</summary>
    void GetResult();

    /// <summary>Cancels the operation and releases resources.</summary>
    void Cancel();
}