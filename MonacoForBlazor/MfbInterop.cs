using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MonacoForBlazor.Api;
using MonacoForBlazor.Api.Dtos;
using System.Collections.Generic;
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
        public static async Task Create(this IJSRuntime jsRuntime, string id, EditorOptions options = null)
        {
            await jsRuntime.InvokeAsync<object>("MonacoForBlazor.editorInitialize", 
                id, 
                options ?? new EditorOptions());
        }

        /// <summary>
        /// Apply the same font settings as the editor to target.
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <param name="target">Target HTML element of the operation.</param>
        public static async Task ApplyFontInfo(this IJSRuntime jsRuntime, string id, ElementReference target)
        {
            await jsRuntime.InvokeAsync<object>("MonacoForBlazor.applyFontInfo", id, target);
        }


        /// <summary>
        /// Disposes a previously created editor and releases its resources.
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <returns>True, if the editor was released; otherwise, false.</returns>
        public static async Task<bool> Dispose(this IJSRuntime jsRuntime, string id)
        {
            return await jsRuntime.InvokeAsync<bool>("MonacoForBlazor.dispose", id);
        }

        /// <summary>
        /// Gets the type of the editor
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <returns>The string that names the editor type</returns>
        public static async Task<string> GetEditorType(this IJSRuntime jsRuntime, string id)
        {
            return await jsRuntime.InvokeAsync<string>("MonacoForBlazor.getEditorType", id);
        }

        /// <summary>
        /// Get the scrollHeight of the editor's viewport.
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        public static async Task<double> GetScrollHeight(this IJSRuntime jsRuntime, string id)
        {
            return await jsRuntime.InvokeAsync<double>("MonacoForBlazor.getScrollHeight", id);
        }

        /// <summary>
        /// Get the scrollLeft of the editor's viewport.
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        public static async Task<double> GetScrollLeft(this IJSRuntime jsRuntime, string id)
        {
            return await jsRuntime.InvokeAsync<double>("MonacoForBlazor.getScrollLeft", id);
        }

        /// <summary>
        /// Get the scrollTop of the editor's viewport.
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        public static async Task<double> GetScrollTop(this IJSRuntime jsRuntime, string id)
        {
            return await jsRuntime.InvokeAsync<double>("MonacoForBlazor.getScrollTop", id);
        }

        /// <summary>
        /// Get the scrollWidth of the editor's viewport.
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        public static async Task<double> GetScrollWidth(this IJSRuntime jsRuntime, string id)
        {
            return await jsRuntime.InvokeAsync<double>("MonacoForBlazor.getScrollWidth", id);
        }

        /// <summary>
        /// Get the visible position for the specifid position. 
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <param name="position">Position to use</param>
        public static async Task<VisiblePosition> GetScrolledVisiblePosition(this IJSRuntime jsRuntime, string id, Position position)
        {
            return await jsRuntime.InvokeAsync<VisiblePosition>("MonacoForBlazor.getScrolledVisiblePosition", id, position);
        }

        /// <summary>
        /// Get the visible position for the specifid position. 
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        public static async Task<Selection> GetSelection(this IJSRuntime jsRuntime, string id)
        {
            var dto = await jsRuntime.InvokeAsync<SelectionDto>("MonacoForBlazor.getSelection", id);
            return new Selection(dto.SelectionStartLineNumber,
                dto.SelectionStartColumn,
                dto.PositionLineNumber,
                dto.PositionColumn);
        }

        /// <summary>
        /// Get the visible position for the specifid position. 
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        public static async Task<Selection[]> GetSelections(this IJSRuntime jsRuntime, string id)
        {
            var dtoArr = await jsRuntime.InvokeAsync<SelectionDto[]>("MonacoForBlazor.getSelections", id);
            if (dtoArr == null) return null;
            var result = new Selection[dtoArr.Length];
            for (var i = 0; i < dtoArr.Length; i++)
            {
                var dto = dtoArr[i];
                result[i] = new Selection(dto.SelectionStartLineNumber,
                dto.SelectionStartColumn,
                dto.PositionLineNumber,
                dto.PositionColumn);
            }
            return result;
        }

        /// <summary>
        /// Releases a previously created editor
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <returns>True, if the editor was released; otherwise, false.</returns>
        public static async Task<bool> Release(this IJSRuntime jsRuntime, string id)
        {
            return await jsRuntime.InvokeAsync<bool>("MonacoForBlazor.release", id);
        }

        /// <summary>
        /// Sets the focus to the specified editor
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <returns>True, if the editor was released; otherwise, false.</returns>
        public static async Task Focus(this IJSRuntime jsRuntime, string id)
        {
            await jsRuntime.InvokeAsync<object>("MonacoForBlazor.focus", id);
        }
    }
}
