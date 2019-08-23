using Microsoft.JSInterop;
using MonacoForBlazor.Api;
using System.Threading.Tasks;

namespace MonacoForBlazor
{
    public static class MfbInterop
    {
        /// <summary>
        /// Creates a new editor with the specified id
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the HTML element nesting the editor</param>
        /// <param name="options">Options to create the edito</param>
        /// <returns></returns>
        public static async Task CreateEditor(this IJSRuntime jsRuntime, string id, EditorOptions options = null)
        {
            await jsRuntime.InvokeAsync<object>("MonacoForBlazor.editorInitialize", 
                id, 
                options ?? new EditorOptions());
        }
    }
}
