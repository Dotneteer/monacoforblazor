using System.Collections.Generic;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Thsi class represents the options to create an editor.
    /// </summary>
    public class EditorOptions
    {
        /// <summary>
        /// Accept suggestions on provider defined characters.
        /// Defaults to true.
        /// </summary>
        public bool AcceptSuggestionOnCommitCharacter { get; set; } = true;

        /// <summary>
        /// Accept suggestions on ENTER.
        /// Defaults to 'on'.
        /// </summary>
        public string AcceptSuggestionOnEnter { get; set; } = AcceptSuggestionOnEnterValues.On;

        /// <summary>
        /// An URL to open when Ctrl+H (Windows and Linux) or Cmd+H (OSX) is pressed in the 
        /// accessibility help dialog in the editor.
        /// Defaults to "https://go.microsoft.com/fwlink/?linkid=852450"
        /// </summary>
        public string AccessibilityHelpUrl { get; set; }

        /// <summary>
        /// Configure the editor's accessibility support. Defaults to 'auto'.
        /// It is best to leave this to 'auto'.
        /// </summary>
        public string AccessibilitySupport { get; set; } = "auto";

        /// <summary>
        /// The aria label for the editor's textarea (when it is focused). 
        /// </summary>
        public string AriaLabel { get; set; }

        /// <summary>
        /// Options for auto closing brackets. Defaults to language defined behavior.
        /// </summary>
        /// <remarks>
        /// For values, use the string constants of <see cref="EditorAutoClosingStrategy"/>, or null.
        /// </remarks>
        public string AutoClosingBrackets { get; set; }

        /// <summary>
        /// Options for auto closing quotes. Defaults to language defined behavior.
        /// </summary>
        /// <remarks>
        /// For values, use the string constants of <see cref="EditorAutoClosingStrategy"/>, or null.
        /// </remarks>
        public string AutoClosingQuotes { get; set; }

        /// <summary>
        /// Enable auto indentation adjustment. Defaults to false. 
        /// </summary>
        public bool AutoIndent { get; set; } = false;

        /// <summary>
        /// Options for auto surrounding. Defaults to always allowing auto surrounding.
        /// </summary>
        public string AutoSurround { get; set; }

        /// <summary>
        /// Enable that the editor will install an interval to check if its container dom node size has changed.
        /// Enabling this might have a severe performance impact.
        /// Defaults to false.
        /// </summary>
        public bool AutomaticLayout { get; set; } = false;

        /// <summary>
        /// Code action kinds to be run on save.
        /// </summary>
        public Dictionary<string, bool> CodeActionsOnSave { get; set; }

        /// <summary>
        /// Timeout for running code actions on save.
        /// </summary>
        public int? CodeActionsOnSaveTimeout { get; set; }

        /// <summary>
        /// Show code lens. Defaults to true.
        /// </summary>
        public bool CodeLens { get; set; } = true;

        /// <summary>
        /// Enable inline color decorators and color picker rendering. Defaults to true.
        /// </summary>
        public bool ColorDecorators { get; set; } = true;

        /// <summary>
        /// Enable custom contextmenu. Defaults to true.
        /// </summary>
        public bool Contextmenu { get; set; } = true;

        /// <summary>
        /// Syntax highlighting is copied. Defaults to true.
        /// </summary>
        public bool CopyWithSyntaxHighlighting { get; set; } = true;

        /// <summary>
        /// Control the cursor animation style, possible values are 'blink', 'smooth', 'phase', 'expand' and 'solid'.
        /// Defaults to 'blink'.
        /// </summary>
        /// <remarks>
        /// For values, use the string constants of <see cref="CursorBlinkingValues"/>, or null.
        /// </remarks>
        public string CursorBlinking { get; set; } = CursorBlinkingValues.Blink;

        /// <summary>
        /// Enable smooth caret animation. Defaults to false.
        /// </summary>
        public bool CursorSmoothCaretAnimation { get; set; } = false;

        /// <summary>
        /// Control the cursor style, either 'block' or 'line'. Defaults to 'line'.
        /// </summary>
        /// <remarks>
        /// For values, use the string constants of <see cref="CursorStyleValues"/>, or null.
        /// </remarks>
        public string CursorStyle { get; set; } = CursorStyleValues.Line;

        /// <summary>
        /// Control the width of the cursor when cursorStyle is set to 'line'
        /// </summary>
        public double? CursorWidth { get; set; }

        /// <summary>
        /// Disable the use of `will-change` for the editor margin and lines layers.
        /// The usage of `will-change` acts as a hint for browsers to create an extra layer.
        /// Defaults to false.
        /// </summary>
        public bool DisableLayerHinting { get; set; } = false;

        /// <summary>
        /// Disable the optimizations for monospace fonts. Defaults to false.
        /// </summary>
        public bool DisableMonospaceOptimizations { get; set; } = false;

        /// <summary>
        /// Controls if the editor should allow to move selections via drag and drop.
        /// Defaults to false.
        /// </summary>
        public bool DragAndDrop { get; set; } = false;

        /// <summary>
        /// Copying without a selection copies the current line. Defaults to true.
        /// </summary>
        public bool EmptySelectionClipboard { get; set; } = true;

        /// <summary>
        /// Class name to be added to the editor.
        /// </summary>
        public string ExtraEditorClassName { get; set; }

        /// <summary>
        /// Fast scrolling mulitplier speed when pressing `Alt`
        /// Defaults to 5.
        /// </summary>
        public int FastScrollSensitivity { get; set; } = 5;

        /// <summary>
        /// Control the behavior of the find widget.
        /// </summary>
        public EditorFindOptions Find { get; set; }

        /// <summary>
        /// Display overflow widgets as `fixed`.
        /// Defaults to `false`.
        /// </summary>
        public bool FixedOverflowWidgets { get; set; } = false;

        /// <summary>
        /// Enable code folding. Defaults to true.
        /// </summary>
        public bool Folding { get; set; } = true;

        /// <summary>
        /// Selects the folding strategy. 'auto' uses the strategies contributed for the 
        /// current document, 'indentation' uses the indentation based folding strategy.
        /// Defaults to 'auto'.
        /// </summary>
        public string FoldingStrategy { get; set; } = EditorFoldingStrategy.Auto;

        /// <summary>
        /// The font family
        /// </summary>
        public string FontFamily { get; set; }

        /// <summary>
        /// Enable font ligatures. Defaults to false.
        /// </summary>
        public bool FontLigatures { get; set; } = false;

        /// <summary>
        /// The font size of the editor.
        /// </summary>
        public double? FontSize { get; set; }

        /// <summary>
        /// The font weight of the editor. Available values: 'normal', 'bold', 'bolder',
        /// 'lighter', 'initial', 'inherit', '100', '200', '300', '400', '500', '600', '700', '800', '900'.
        /// </summary>
        public string FontWeight { get; set; }

        /// <summary>
        /// Enable format on paste.
        /// Defaults to false.
        /// </summary>
        public bool FormatOnPaste { get; set; } = false;

        /// <summary>
        /// Enable format on type.
        /// Defaults to false.
        /// </summary>
        public bool FormatOnType { get; set; } = false;

        /// <summary>
        /// Enable the rendering of the glyph margin.
        /// Defaults to false.
        /// </summary>
        public bool GlyphMargin { get; set; } = false;

        /// <summary>
        /// Sets the options to handle goto command with multiple results.
        /// </summary>
        public GoToLocationOptions GotoLocation { get; set; }

        /// <summary>
        /// Should the cursor be hidden in the overview ruler.
        /// Defaults to false.
        /// </summary>
        public bool HideCursorInOverviewRuler { get; set; }

        /// <summary>
        /// Enable highlighting of the active indent guide.
        /// Defaults to true.
        /// </summary>
        public bool HighlightActiveIndentGuide { get; set; } = true;

        /// <summary>
        /// Configure the editor's hover.
        /// </summary>
        public EditorHoverOptions Hover { get; set; }

        /// <summary>
        /// The initial language of the auto created model in the editor. To not create 
        /// automatically a model, use model null.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The letter spacing
        /// </summary>
        public double? LetterSpacing { get; set; }

        /// <summary>
        /// Control the behavior and rendering of the code action lightbulb.
        /// </summary>
        public EditorLightbulbOptions Lightbulb { get; set; }

        /// <summary>
        /// The width reserved for line decorations (in px).
        /// Line decorations are placed between line numbers and the editor content.
        /// You can pass in a string in the format floating point followed by "ch". e.g. 1.3ch.
        /// Defaults to 10.
        /// </summary>
        public string LineDecorationsWidth { get; set; } = "10px";

        /// <summary>
        /// The height of a line.
        /// </summary>
        public double? LineHeight { get; set; }

        /// <summary>
        /// Control the rendering of line numbers.
        /// If it is a truey, line numbers will be rendered normally (equivalent of using an identity function).
        /// Otherwise, line numbers will not be rendered.
        /// Defaults to 'on'.
        /// </summary>
        public string LineNumbers { get; set; } = LineNumberValues.On;

        /// <summary>
        /// Control the width of line numbers, by reserving horizontal space for rendering at least an amount of digits.
        /// Defaults to 5.
        /// </summary>
        public int LineNumbersMinChars { get; set; } = 5;

        /// <summary>
        /// Enable detecting links and making them clickable.
        /// Defaults to true.
        /// </summary>
        public bool Links { get; set; } = true;

        /// <summary>
        /// Enable highlighting of matching brackets.
        /// Defaults to true.
        /// </summary>
        public bool MatchBrackets { get; set; }

        /// <summary>
        /// Control the behavior and rendering of the minimap.
        /// </summary>
        public EditorMinimapOptions Minimap { get; set; }

        /// <summary>
        /// The initial model associated with this code editor.
        /// </summary>
        public TextModel Model { get; set; } = null;

        /// <summary>
        /// A multiplier to be used on the `deltaX` and `deltaY` of mouse wheel scroll events.
        /// Defaults to 1.
        /// </summary>
        public int MouseWheelScrollSensitivity { get; set; } = 1;

        /// <summary>
        /// Zoom the font in the editor when using the mouse wheel in combination with holding Ctrl.
        /// Defaults to false.
        /// </summary>
        public bool MouseWheelZoom { get; set; } = false;

        /// <summary>
        /// Merge overlapping selections.
        /// Defaults to true
        /// </summary>
        public bool MultiCursorMergeOverlapping { get; set; } = true;

        /// <summary>
        /// The modifier to be used to add multiple cursors with the mouse.
        /// Defaults to 'alt'
        /// </summary>
        public string MultiCursorModifier { get; set; } = MultiCursorModifierValue.Alt;

        /// <summary>
        /// Enable semantic occurrences highlight.
        /// Defaults to true.
        /// </summary>
        public bool OccurrencesHighlight { get; set; } = true;

        /// <summary>
        /// Controls if a border should be drawn around the overview ruler.
        /// Defaults to `true`.
        /// </summary>
        public bool OverviewRulerBorder { get; set; } = true;

        /// <summary>
        /// The number of vertical lanes the overview ruler should render.
        /// Defaults to 2.
        /// </summary>
        public int OverviewRulerLanes { get; set; } = 2;

        /// <summary>
        /// Parameter hint options.
        /// </summary>
        public EditorParameterHintOptions ParameterHints { get; set; }

        /// <summary>
        /// Enable quick suggestions (shadow suggestions)
        /// Defaults to true.
        /// </summary>
        public QuickSuggestionOptions QuickSuggestions { get; set; } = new QuickSuggestionOptions();

        /// <summary>
        /// Quick suggestions show delay (in ms) Defaults to 500 (ms)
        /// </summary>
        public int QuickSuggestionsDelay { get; set; } = 500;

        /// <summary>
        /// Should the editor be read only.
        /// Defaults to false.
        /// </summary>
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Enable rendering of control characters.
        /// Defaults to false.
        /// </summary>
        public bool RenderControlCharacters { get; set; } = false;

        /// <summary>
        /// Render last line number when the file ends with a newline.
        /// Defaults to true.
        /// </summary>
        public bool RenderFinalNewline { get; set; } = true;

        /// <summary>
        /// Enable rendering of indent guides.
        /// Defaults to true.
        /// </summary>
        public bool RenderIndentGuides { get; set; } = true;

        /// <summary>
        /// Enable rendering of current line highlight.
        /// Defaults to 'all'.
        /// </summary>
        public string RenderLineHighlight { get; set; } = RenderLineHighlightValues.All;

        /// <summary>
        /// Enable rendering of whitespace.
        /// Defaults to none.
        /// </summary>
        public string RenderWhitespace { get; set; } = RenderWhitespaceValues.None;

        /// <summary>
        /// When revealing the cursor, a virtual padding (px) is added to the cursor, turning it into a rectangle.
        /// This virtual padding ensures that the cursor gets revealed before hitting the edge of the viewport.
        /// Defaults to 30 (px).
        /// </summary>
        public int RevealHorizontalRightPadding { get; set; } = 30;

        /// <summary>
        /// Render the editor selection with rounded borders.
        /// Defaults to true.
        /// </summary>
        public bool RoundedSelection { get; set; } = true;

        /// <summary>
        /// Render vertical lines at the specified columns.
        /// Defaults to empty array.
        /// </summary>
        public int[] Rulers { get; set; } = new int[0];

        /// <summary>
        /// Enable that scrolling can go beyond the last column by a number of columns.
        /// Defaults to 5.
        /// </summary>
        public int ScrollBeyondLastColumn { get; set; } = 5;

        /// <summary>
        /// Enable that scrolling can go one screen size after the last line.
        /// Defaults to true.
        /// </summary>
        public bool ScrollBeyondLastLine { get; set; }

        /// <summary>
        /// Control the behavior and rendering of the scrollbars.
        /// </summary>
        public EditorScrollbarOptions Scrollbar { get; set; }

        /// <summary>
        /// Should the corresponding line be selected when clicking on the line number?
        /// Defaults to true.
        /// </summary>
        public bool SelectOnLineNumbers { get; set; } = true;

        /// <summary>
        /// Enable Linux primary clipboard.
        /// Defaults to true.
        /// </summary>
        public bool SelectionClipboard { get; set; } = true;

        /// <summary>
        /// Enable selection highlight.
        /// Defaults to true.
        /// </summary>
        public bool SelectionHighlight { get; set; } = true;

        /// <summary>
        /// Controls whether the fold actions in the gutter stay always visible or hide unless the mouse is over the gutter.
        /// Defaults to 'mouseover'.
        /// </summary>
        public string ShowFoldingControls { get; set; } = ShowPartValues.MouseOver;

        /// <summary>
        /// Controls fading out of unused variables.
        /// </summary>
        public bool? ShowUnused { get; set; }

        /// <summary>
        /// Enable that the editor animates scrolling to a position.
        /// Defaults to false.
        /// </summary>
        public bool SmoothScrolling { get; set; } = false;

        /// <summary>
        /// Enable snippet suggestions. Default to 'inline'.
        /// </summary>
        public string SnippetSuggestions { get; set; } = SnippetSuggestionValues.Inline;

        /// <summary>
        /// Performance guard: Stop rendering a line after x characters.
        /// Defaults to 10000.
        /// Use -1 to never stop rendering
        /// </summary>
        public int StopRenderingLineAfter { get; set; } = 10000;

        /// <summary>
        /// Suggest options.
        /// </summary>
        public SuggestOptions Suggest { get; set; }

        /// <summary>
        /// The font size for the suggest widget. Defaults to the editor font size.
        /// </summary>
        public double? SuggestFontSize { get; set; }

        /// <summary>
        /// The line height for the suggest widget.
        /// Defaults to the editor line height.
        /// </summary>
        public double? SuggestLineHeight { get; set; }

        /// <summary>
        /// Enable the suggestion box to pop-up on trigger characters.
        /// Defaults to true.
        /// </summary>
        public bool SuggestOnTriggerCharacters { get; set; } = true;

        /// <summary>
        /// The history mode for suggestions.
        /// Defaults to 'recentlyUsed'
        /// </summary>
        public string SuggestSelection { get; set; } = SuggestSelectionValues.RecentlyUsed;

        /// <summary>
        /// Enable tab completion.
        /// Defaults to "off".
        /// </summary>
        public string TabCompletion { get; set; } = TabCompletionValues.Off;

        /// <summary>
        /// Initial theme to be used for rendering. The current out-of-the-box available 
        /// themes are: 'vs' (default), 'vs-dark', 'hc-black'. You can create custom 
        /// themes via monaco.editor.defineTheme. To switch a theme, use monaco.editor.setTheme
        /// </summary>
        public string Theme { get; set; }

        /// <summary>
        /// Inserting and deleting whitespace follows tab stops.
        /// Defaults to true.
        /// </summary>
        public bool UseTabStops { get; set; } = true;

        /// <summary>
        /// The initial value of the auto created model in the editor. To not create 
        /// automatically a model, use model: null.
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Enable word based suggestions. Defaults to 'true'
        /// </summary>
        public bool WordBasedSuggestions { get; set; } = true;

        /// <summary>
        /// A string containing the word separators used when doing word navigation.
        /// Defaults to `~!@#$%^&*()-=+[{]}\\|;:\'",.<>/?
        /// </summary>
        public string WordSeparators { get; set; }

        /// <summary>
        /// Control the wrapping of the editor.
        /// When `wordWrap` = "off", the lines will never wrap.
        /// When `wordWrap` = "on", the lines will wrap at the viewport width.
        /// When `wordWrap` = "wordWrapColumn", the lines will wrap at `wordWrapColumn`.
        /// When `wordWrap` = "bounded", the lines will wrap at min(viewport width, wordWrapColumn).
        /// Defaults to "off".
        /// </summary>
        public string WordWrap { get; set; } = WordWrapValues.Off;

        /// <summary>
        /// Configure word wrapping characters. A break will be introduced after these characters.
        /// Defaults to ' \t})]?|&,;'.
        /// </summary>
        public string WordWrapBreakAfterCharacters { get; set; }

        /// <summary>
        /// Configure word wrapping characters. A break will be introduced before these characters.
        /// Defaults to '{([+'.
        /// </summary>
        public string WordWrapBreakBeforeCharacters { get; set; }

        /// <summary>
        /// Configure word wrapping characters. A break will be introduced after these characters only 
        /// if no `wordWrapBreakBeforeCharacters` or `wordWrapBreakAfterCharacters` were found.
        /// Defaults to '.'.
        /// </summary>
        public string WordWrapBreakObtrusiveCharacters { get; set; }

        /// <summary>
        /// Control the wrapping of the editor.
        /// When `wordWrap` = "off", the lines will never wrap.
        /// When `wordWrap` = "on", the lines will wrap at the viewport width.
        /// When `wordWrap` = "wordWrapColumn", the lines will wrap at `wordWrapColumn`.
        /// When `wordWrap` = "bounded", the lines will wrap at min(viewport width, wordWrapColumn).
        /// Defaults to 80.
        /// </summary>
        public int WordWrapColumn { get; set; } = 80;

        /// <summary>
        /// Force word wrapping when the text appears to be of a minified/generated file.
        /// Defaults to true.
        /// </summary>
        public bool WordWrapMinified { get; set; } = true;

        /// <summary>
        /// Control indentation of wrapped lines. Can be: 'none', 'same', 'indent' or 'deepIndent'.
        /// Defaults to 'same' in vscode and to 'none' in monaco-editor.
        /// </summary>
        public string WrappingIndent { get; set; } = WrappingIndentValues.None;
    }
}
