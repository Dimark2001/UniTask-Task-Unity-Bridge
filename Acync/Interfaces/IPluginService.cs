using System.Threading;

public interface IPluginService
{
    IAsyncOperation FetchDataAsync(CancellationToken ct);
}