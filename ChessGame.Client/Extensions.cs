using Microsoft.JSInterop;

namespace ChessGame.Client
{
    public static class Extensions
    {
        public static async Task LogAsync(this IJSRuntime js, params object?[]? args)
        {
            await js.InvokeVoidAsync("console.log", args);
        }
    }
}
