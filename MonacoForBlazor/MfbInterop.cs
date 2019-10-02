using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MonacoForBlazor.Api;
using MonacoForBlazor.Api.Abstractions;
using MonacoForBlazor.Api.Dtos;
using MonacoForBlazor.Api.Internals;
using System.Collections.ObjectModel;
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
        /// Returns the current editor's configuration
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <returns>Editor configuration</returns>
        public static async Task<IEditorConfiguration> GetConfiguration(this IJSRuntime jsRuntime, string id)
        {
            var config = await jsRuntime.InvokeAsync<EditorConfigurationDto>("MonacoForBlazor.getConfiguration", id);
            var contribInfo = config.ContribInfo;
            var suggest = contribInfo.Suggest;
            var suggestInfo = suggest == null ? null : new InternalSuggestOptions
            {
                FilteredTypes = new ReadOnlyDictionary<string, bool>(suggest.FilteredTypes),
                FilterGraceful = suggest.FilterGraceful,
                LocalityBonus = suggest.LocalityBonus,
                MaxVisibleSuggestions = suggest.MaxVisibleSuggestions,
                ShareSuggestSelections = suggest.ShareSuggestSelections,
                ShowIcons = suggest.ShowIcons,
                SnippetsPreventQuickSuggestions = suggest.SnippetsPreventQuickSuggestions
            };
            var viewInfo = config.ViewInfo;
            return new InternalEditorConfiguration
            {
                AutoClosingBrackets = config.AutoClosingBrackets,
                AutoClosingQuotes = config.AutoClosingQuotes,
                AutoIndent = config.AutoIndent,
                AutoSurround = config.AutoSurround,
                CanUseLayerHinting = config.CanUseLayerHinting,
                ContribInfo = new InternalEditorContribOptions
                {
                    AcceptSuggestionOnCommitCharacter = contribInfo.AcceptSuggestionOnCommitCharacter,
                    AcceptSuggestionOnEnter = contribInfo.AcceptSuggestionOnEnter,
                    CodeActionsOnSave = new ReadOnlyDictionary<string, bool>(contribInfo.CodeActionsOnSave),
                    CodeActionsOnSaveTimeout = contribInfo.CodeActionsOnSaveTimeout,
                    CodeLens = contribInfo.CodeLens,
                    ColorDecorators = contribInfo.ColorDecorators,
                    Contextmenu = contribInfo.Contextmenu,
                    Find = contribInfo.Find,
                    Folding = contribInfo.Folding,
                    FoldingStrategy = contribInfo.FoldingStrategy,
                    FormatOnPaste = contribInfo.FormatOnPaste,
                    FormatOnType = contribInfo.FormatOnType,
                    GotoLocation = contribInfo.GotoLocation,
                    Hover = contribInfo.Hover,
                    LightbulbEnabled = contribInfo.LightbulbEnabled,
                    Links = contribInfo.Links,
                    MatchBrackets = contribInfo.MatchBrackets,
                    OccurrencesHighlight = contribInfo.OccurrencesHighlight,
                    ParameterHints = contribInfo.ParameterHints,
                    QuickSuggestionOptions = contribInfo.QuickSuggestionOptions,
                    QuickSuggestions = contribInfo.QuickSuggestions,
                    QuickSuggestionsDelay = contribInfo.QuickSuggestionsDelay,
                    SelectionClipboard = contribInfo.SelectionClipboard,
                    SelectionHighlight = contribInfo.SelectionHighlight,
                    ShowFoldingControls = contribInfo.ShowFoldingControls,
                    Suggest = suggestInfo,
                    SuggestFontSize = contribInfo.SuggestFontSize,
                    SuggestLineHeight = contribInfo.SuggestLineHeight,
                    SuggestOnTriggerCharacters = contribInfo.SuggestOnTriggerCharacters,
                    SuggestSelection = contribInfo.SuggestSelection,
                    TabCompletion = contribInfo.TabCompletion,
                    WordBasedSuggestions = contribInfo.WordBasedSuggestions
                },
                CopyWithSyntaxHighlighting = config.CopyWithSyntaxHighlighting,
                DragAndDrop = config.DragAndDrop,
                EditorClassName = config.EditorClassName,
                EmptySelectionClipboard = config.EmptySelectionClipboard,
                FontInfo = config.FontInfo,
                LayoutInfo = config.LayoutInfo,
                LineHeight = config.LineHeight,
                MultiCursorMergeOverlapping = config.MultiCursorMergeOverlapping,
                MultiCursorModifier = config.MultiCursorModifier,
                PixelRatio = config.PixelRatio,
                ReadOnly = config.ReadOnly,
                ShowUnused = config.ShowUnused,
                TabFocusMode = config.TabFocusMode,
                UseTabStops = config.UseTabStops,
                ViewInfo = new InternalEditorViewOptions
                {
                    AriaLabel = viewInfo.AriaLabel,
                    CursorBlinking = viewInfo.CursorBlinking,
                    CursorSmoothCaretAnimation = viewInfo.CursorSmoothCaretAnimation,
                    CursorStyle = viewInfo.CursorStyle,
                    CursorSurroundingLines = viewInfo.CursorSurroundingLines,
                    CursorWidth = viewInfo.CursorWidth,
                    DisableMonospaceOptimizations = viewInfo.DisableMonospaceOptimizations,
                    ExtraEditorClassName = viewInfo.ExtraEditorClassName,
                    FixedOverflowWidgets = viewInfo.FixedOverflowWidgets,
                    FontLigatures = viewInfo.FontLigatures,
                    GlyphMargin = viewInfo.GlyphMargin,
                    HideCursorInOverviewRuler = viewInfo.HideCursorInOverviewRuler,
                    HighlightActiveIndentGuide = viewInfo.HighlightActiveIndentGuide,
                    Minimap = viewInfo.Minimap,
                    MouseWheelZoom = viewInfo.MouseWheelZoom,
                    OverviewRulerBorder = viewInfo.OverviewRulerBorder,
                    OverviewRulerLanes = viewInfo.OverviewRulerLanes,
                    RenderControlCharacters = viewInfo.RenderControlCharacters,
                    RenderFinalNewline = viewInfo.RenderFinalNewline,
                    RenderIndentGuides = viewInfo.RenderIndentGuides,
                    RenderLineHighlight = viewInfo.RenderLineHighlight,
                    RenderLineNumbers = viewInfo.RenderLineNumbers,
                    RenderWhitespace = viewInfo.RenderWhitespace,
                    RevealHorizontalRightPadding = viewInfo.RevealHorizontalRightPadding,
                    RoundedSelection = viewInfo.RoundedSelection,
                    Rulers = viewInfo.Rulers,
                    Scrollbar = viewInfo.Scrollbar,
                    ScrollBeyondLastColumn = viewInfo.ScrollBeyondLastColumn,
                    ScrollBeyondLastLine = viewInfo.ScrollBeyondLastLine,
                    SelectOnLineNumbers = viewInfo.SelectOnLineNumbers,
                    SmoothScrolling = viewInfo.SmoothScrolling,
                    StopRenderingLineAfter = viewInfo.StopRenderingLineAfter
                },
                WordSeparators = config.WordSeparators,
                WrappingInfo = config.WrappingInfo
            };
        }

        /// <summary>
        /// Returns the editor's dom node
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <returns>The element ID of the DOM node</returns>
        public static async Task<string> GetDomNode(this IJSRuntime jsRuntime, string id)
        {
            return await jsRuntime.InvokeAsync<string>("MonacoForBlazor.getDomNode", id);
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
        /// Get the hit test target at coordinates clientX and clientY. The 
        /// coordinates are relative to the top-left of the viewport.
        /// </summary>
        /// <param name="jsRuntime">JS runtime object</param>
        /// <param name="id">ID of the editor</param>
        /// <param name="clientX">Client X position</param>
        /// <param name="clientY">Client Y position</param>
        public static async Task<MouseTarget> GetTargetAtClientPoint(this IJSRuntime jsRuntime, 
            string id, 
            int clientX,
            int clientY)
        {
            var dto = await jsRuntime.InvokeAsync<MouseTargetDto>("MonacoForBlazor.getTargetAtClientPoint", 
                id, clientX, clientY);
            return new MouseTarget
            {
                ElementId = dto.ElementId,
                Type = dto.Type,
                MouseColumn = dto.MouseColumn,
                Position = new Position(dto.Position.LineNumber, dto.Position.Column),
                Range = new Range(dto.Range.StartLineNumber, dto.Range.StartColumn,
                    dto.Range.EndLineNumber, dto.Range.EndColumn)
            };
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
