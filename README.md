A lightweight abstraction layer for seamless async operations in Unity, supporting both Task (C#) and UniTask (Cysharp) with automatic platform detection.

✔ Works in WebGL (via UniTask)
✔ Cancellation support
✔ Error handling
✔ Awaitable interface

Installation
Dependencies
UniTask (Required for WebGL)

sh
# Install via UPM (Unity Package Manager)
https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask
Manual Setup
Clone this repository into your Unity project’s Assets/Scripts/ folder.

Ensure the UNITASK_AVAILABLE symbol is defined if using UniTask.

Usage
1. Basic Async Operation
csharp
using UnityEngine;
using System.Threading;

public class Example : MonoBehaviour
{
    private async void Start()
    {
        var operation = AsyncOperationFactory.Create(async (ct) =>
        {
            await Task.Delay(1000, ct); // Or UniTask.Delay(1000, ct)
            Debug.Log("Operation completed!");
        });

        try
        {
            await operation; // Uses IAsyncOperation's GetAwaiter()
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed: {ex.Message}");
        }
    }
}
2. Cancellable Service
csharp
public class WeatherService : IPluginService
{
    public IAsyncOperation FetchDataAsync(CancellationToken ct)
    {
        return AsyncOperationFactory.Create(async (token) =>
        {
            await UniTask.Delay(1500, cancellationToken: token); // Simulate API call
            return "Sunny"; // (In real code, return JSON/data)
        });
    }
}

// Usage:
CancellationTokenSource _cts = new CancellationTokenSource();

async void LoadWeather()
{
    var service = new WeatherService();
    var operation = service.FetchDataAsync(_cts.Token);

    try { Debug.Log(await operation); }
    catch (OperationCanceledException) { Debug.Log("Cancelled!"); }
}

void Cancel() => _cts.Cancel(); // Call to abort
API Reference
Interfaces
Interface	Description
IAsyncOperation	Core async contract (awaitable, cancellable).
IPluginService	Optional for service pattern (e.g., APIs).
Factory
csharp
// For Task (non-WebGL):
AsyncOperationFactory.Create(Func<CancellationToken, Task> taskFactory);

// For UniTask (WebGL-friendly):
AsyncOperationFactory.Create(Func<CancellationToken, UniTask> uniTaskFactory);
Key Methods
Method	Purpose
GetResult()	Throws stored exceptions or returns result.
Cancel()	Aborts the operation and cleans up resources.
OnCompleted(Action)	Used by await for continuations.
Platform Notes
WebGL: Uses UniTask (auto-fallback via #if UNITY_WEBGL).

Other Platforms: Uses standard Task for better performance.

