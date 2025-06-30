public static class AsyncOperationExtensions
{
    public static IAsyncOperation GetAwaiter(this IAsyncOperation operation) => operation;
}