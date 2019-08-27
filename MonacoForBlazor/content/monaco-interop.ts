/**
 * Associates editors with their IDs
 */
type EditorMap = { [key: string]: monaco.editor.IStandaloneCodeEditor };

/**
 * An entry in the cache
 */
interface CachedObjectInfo {
    item: any,
    type: string,
    expires: number
}

/**
 * DTO for an IMouseTarget
 */
interface MouseTargetDto {
    elementId: string | null;
    type: monaco.editor.MouseTargetType;
    readonly position: monaco.IPosition | null;
    readonly mouseColumn: number;
    readonly range: monaco.IRange | null;
}

/**
 * The type of the cache
 */
type ObjectCache = { [key: string]: CachedObjectInfo }

/**
 * Encapsule the Monace interop API
 */
class MonacoForBlazorJsInterop {
    // --- We keep initialized editors here
    private readonly editors: EditorMap = {};

    // --- We keep cached objects here
    private readonly _objectCache: ObjectCache = {};
    private readonly EXPIRATION_TIMEOUT = 10000;
    private _objectSeqNo = 0;

    /**
     * Initializes the API
     */
    public constructor() {
        this._setExpirationScan();
    }

    /**
     * Get the editor with the specified ID
     * @param editorId ID of the editor
     */
    private _getEditor(editorId: string) {
        return this.editors[editorId];
    }

    /**
     * Ensures that the specified editor has been created
     * @param editorId ID of the editor
     *
     * Throws an error if the editor has not been created, or 
     * already disposed.
     */
    private _ensureEditor(editorId): monaco.editor.IStandaloneCodeEditor {
        var editor = this._getEditor(editorId);
        if (!editor) {
            throw new Error("Cannot find editor: " + editorId);
        }
        return editor;
    }

    /**
     * Adds an item to the cache
     * @param item Entry to add to the cache
     * @param type Type of cache entry
     */
    private _addToCache(item: any, type: string): string {
        const newId = (this._objectSeqNo++).toString();
        this._objectCache[newId] = {
            item,
            type,
            expires: Date.now() + this.EXPIRATION_TIMEOUT
        };
        return newId;
    }

    /**
     * Removes the specified item from the cache
     * @param objId ID of object to remove
     */
    private _removeFromCache(objId: string) : void {
        delete this._objectCache[objId];
    }

    /**
     * Gets the specified item from the cache
     * @param objId Object ID
     * @param type Object type
     */
    public getFromCache(objId: string, type: string): any {
        const inCache = this._objectCache[objId];
        if (!inCache) return undefined;
        if (!inCache.type || inCache.type !== type) return undefined;
        return inCache.item;
    }

    /**
     * Removes expired items from the cache
     */
    private _removeExpiredItems(): void {
        const now = Date.now();
        let count = 0;
        for (let key in this._objectCache) {
            var expired = this._objectCache[key].expires < now;
            if (expired) {
                delete this._objectCache[key];
            } else {
                count++;
            }
        }
    }

    /**
     * Sets up the interval to remove expired items from the cache
     */
    private _setExpirationScan(): void {
        setInterval(() => {
            this._removeExpiredItems();
            this._setExpirationScan;
        }, this.EXPIRATION_TIMEOUT);
    }

    /**
     * Creates a new editor and initializes it
     * @param editorId ID of the new editor
     * @param ops Editor construction options
     */
    public editorInitialize(editorId: string, ops: monaco.editor.IEditorConstructionOptions) {
        var element = document.getElementById(editorId);

        // --- Remove all child elements
        var child = element.lastElementChild;
        while (child) {
            element.removeChild(child);
            child = element.lastElementChild;
        }

        // --- Create the editor instance
        var newEditor = monaco.editor.create(element, {
            acceptSuggestionOnCommitCharacter: ops.acceptSuggestionOnCommitCharacter,
            acceptSuggestionOnEnter: ops.acceptSuggestionOnEnter,
            accessibilityHelpUrl: ops.accessibilityHelpUrl,
            accessibilitySupport: ops.accessibilitySupport,
            ariaLabel: ops.ariaLabel,
            autoClosingBrackets: ops.autoClosingBrackets,
            autoClosingQuotes: ops.autoClosingQuotes,
            autoIndent: ops.autoIndent,
            autoSurround: ops.autoSurround,
            automaticLayout: ops.automaticLayout,
            codeActionsOnSave: ops.codeActionsOnSave,
            codeActionsOnSaveTimeout: ops.codeActionsOnSaveTimeout,
            codeLens: ops.codeLens,
            colorDecorators: ops.colorDecorators,
            contextmenu: ops.contextmenu,
            copyWithSyntaxHighlighting: ops.copyWithSyntaxHighlighting,
            cursorBlinking: ops.cursorBlinking,
            cursorSmoothCaretAnimation: ops.cursorSmoothCaretAnimation,
            cursorStyle: ops.cursorStyle,
            cursorWidth: ops.cursorWidth,
            disableLayerHinting: ops.disableLayerHinting,
            disableMonospaceOptimizations: ops.disableMonospaceOptimizations,
            dragAndDrop: ops.dragAndDrop,
            emptySelectionClipboard: ops.emptySelectionClipboard,
            extraEditorClassName: ops.extraEditorClassName,
            fastScrollSensitivity: ops.fastScrollSensitivity,
            find: ops.find,
            fixedOverflowWidgets: ops.fixedOverflowWidgets,
            folding: ops.folding,
            foldingStrategy: ops.foldingStrategy,
            fontFamily: ops.fontFamily,
            fontLigatures: ops.fontLigatures,
            fontSize: ops.fontSize,
            fontWeight: ops.fontWeight,
            formatOnPaste: ops.formatOnPaste,
            formatOnType: ops.formatOnType,
            glyphMargin: ops.glyphMargin,
            gotoLocation: ops.gotoLocation,
            hideCursorInOverviewRuler: ops.hideCursorInOverviewRuler,
            highlightActiveIndentGuide: ops.highlightActiveIndentGuide,
            hover: ops.hover,
            language: ops.language,
            letterSpacing: ops.letterSpacing,
            lightbulb: ops.lightbulb,
            lineDecorationsWidth: ops.lineDecorationsWidth,
            lineHeight: ops.lineHeight,
            lineNumbers: ops.lineNumbers,
            lineNumbersMinChars: ops.lineNumbersMinChars,
            links: ops.links,
            matchBrackets: ops.matchBrackets,
            minimap: ops.minimap,
            model: undefined,
            mouseWheelScrollSensitivity: ops.mouseWheelScrollSensitivity,
            mouseWheelZoom: ops.mouseWheelZoom,
            multiCursorMergeOverlapping: ops.multiCursorMergeOverlapping,
            multiCursorModifier: ops.multiCursorModifier,
            occurrencesHighlight: ops.occurrencesHighlight,
            overviewRulerBorder: ops.overviewRulerBorder,
            overviewRulerLanes: ops.overviewRulerLanes,
            parameterHints: ops.parameterHints,
            quickSuggestions: ops.quickSuggestions,
            quickSuggestionsDelay: ops.quickSuggestionsDelay,
            readOnly: ops.readOnly,
            renderControlCharacters: ops.renderControlCharacters,
            renderFinalNewline: ops.renderFinalNewline,
            renderIndentGuides: ops.renderIndentGuides,
            renderLineHighlight: ops.renderLineHighlight,
            renderWhitespace: ops.renderWhitespace,
            revealHorizontalRightPadding: ops.revealHorizontalRightPadding,
            roundedSelection: ops.roundedSelection,
            rulers: ops.rulers,
            scrollBeyondLastColumn: ops.scrollBeyondLastColumn,
            scrollBeyondLastLine: ops.scrollBeyondLastLine,
            scrollbar: ops.scrollbar,
            selectOnLineNumbers: ops.selectOnLineNumbers,
            selectionClipboard: ops.selectionClipboard,
            selectionHighlight: ops.selectionHighlight,
            showFoldingControls: ops.showFoldingControls,
            showUnused: ops.showUnused,
            smoothScrolling: ops.smoothScrolling,
            snippetSuggestions: ops.snippetSuggestions,
            stopRenderingLineAfter: ops.stopRenderingLineAfter,
            suggest: ops.suggest,
            suggestFontSize: ops.suggestFontSize,
            suggestLineHeight: ops.suggestLineHeight,
            suggestOnTriggerCharacters: ops.suggestOnTriggerCharacters,
            suggestSelection: ops.suggestSelection,
            tabCompletion: ops.tabCompletion,
            theme: ops.theme,
            useTabStops: ops.useTabStops,
            value: ops.value,
            wordBasedSuggestions: ops.wordBasedSuggestions,
            wordSeparators: ops.wordSeparators,
            wordWrap: ops.wordWrap,
            wordWrapBreakAfterCharacters: ops.wordWrapBreakAfterCharacters,
            wordWrapBreakBeforeCharacters: ops.wordWrapBreakBeforeCharacters,
            wordWrapBreakObtrusiveCharacters: ops.wordWrapBreakObtrusiveCharacters,
            wordWrapColumn: ops.wordWrapColumn,
            wordWrapMinified: ops.wordWrapMinified,
            wrappingIndent: ops.wrappingIndent
        });

        // --- Save this editor
        this.editors[editorId] = newEditor;
    }

    /**
     * Apply the same font settings as the editor to target.
     * @param editorId ID of the editor
     * @param target Target HTML element
     */
    public applyFontInfo(editorId: string, target: HTMLElement): void {
        const editor = this._ensureEditor(editorId);
        editor.applyFontInfo(target);
    }

    /**
     * Disposes the specified editor
     * @param editorId ID of the editor
     */
    public dispose(editorId: string): boolean {
        const editor = this.editors[editorId];
        if (editor) {
            delete this.editors[editorId];
            editor.dispose();
            return true;
        }
        return false;
    }

    /**
     * Sets the focus to the specified editor
     * @param editorId ID of the editor
     */
    public focus(editorId: string) : void {
        const editor = this._ensureEditor(editorId);
        editor.focus();
    }

    /**
     * Returns the editor's dom node
     * @param editorId ID of the editor
    */
    public getDomNode(editorId: string): string {
        const editor = this._ensureEditor(editorId);
        var element = editor.getDomNode();
        return this._addToCache(element, "HTMLElement");
    }

    /**
     * Gets the type of the editor
     * @param editorId ID of the editor
     */
    public getConfiguration(editorId: string): any {
        const editor = this._ensureEditor(editorId);
        var result = editor.getConfiguration();
        console.log(JSON.stringify(result, null, 2));
        return {
            ...result,
            contribInfo: {
                ...result.contribInfo,
                quickSuggestions: result.contribInfo.quickSuggestions === true
                    || result.contribInfo.quickSuggestions === false
                    ? result.contribInfo.quickSuggestions : null,
                quickSuggestionOptions: result.contribInfo.quickSuggestions === true
                    || result.contribInfo.quickSuggestions === false
                    ? null : result.contribInfo.quickSuggestions,
            }
        }
    }

    /**
     * Gets the type of the editor
     * @param editorId ID of the editor
     */
    public getEditorType(editorId: string) : string {
        const editor = this._ensureEditor(editorId);
        return editor.getEditorType();
    }

    /**
     * Get the scrollHeight of the editor's viewport.
     * @param editorId ID of the editor
     */
    public getScrollHeight(editorId: string) : number {
        const editor = this._ensureEditor(editorId);
        return editor.getScrollHeight();
    }

    /**
     * Get the scrollLeft of the editor's viewport.
     * @param editorId ID of the editor
     */
    public getScrollLeft(editorId: string) : number {
        const editor = this._ensureEditor(editorId);
        return editor.getScrollLeft();
    }

    /**
     * Get the scrollTop of the editor's viewport.
     * @param editorId ID of the editor
     */
    public getScrollTop(editorId: string) : number {
        const editor = this._ensureEditor(editorId);
        return editor.getScrollTop();
    }

    /**
     * Get the scrollWidth of the editor's viewport.
     * @param editorId ID of the editor
     */
    public getScrollWidth(editorId: string) : number {
        const editor = this._ensureEditor(editorId);
        return editor.getScrollWidth();
    }

    /**
     * Get the visible position.
     * @param editorId ID of the editor
     * @param position Position to get the info about
     */
    public getScrolledVisiblePosition(editorId: string, position: monaco.IPosition):
        { top: number, left: number, height: number } {
        const editor = this._ensureEditor(editorId);
        return editor.getScrolledVisiblePosition(position);
    }

    /**
     * Returns the primary selection of the editor.
     * @param editorId ID of the editor
     */
    public getSelection(editorId: string) : monaco.Selection {
        const editor = this._ensureEditor(editorId);
        return editor.getSelection();
    }

    /**
     * Returns all the selections of the editor.
     * @param editorId ID of the editor
     */
    public getSelections(editorId: string) : monaco.Selection[] {
        const editor = this._ensureEditor(editorId);
        return editor.getSelections();
    }

    /**
     * Returns all the selections of the editor.
     * @param editorId ID of the editor
     */
    public getTargetAtClientPoint(editorId: string, clientX: number, clientY: number): MouseTargetDto | null {
        const editor = this._ensureEditor(editorId);
        var result = editor.getTargetAtClientPoint(clientX, clientY);
        if (!result) return null;
        const elementId = this._addToCache(result.element, "HTMLElement");
        return {
            elementId,
            mouseColumn: result.mouseColumn,
            type: result.type,
            position: result.position === null
                ? null
                : {
                    lineNumber: result.position.lineNumber,
                    column: result.position.column
                },
            range: result.range === null
                ? null
                : {
                    startLineNumber: result.range.startLineNumber,
                    startColumn: result.range.startColumn,
                    endLineNumber: result.range.endLineNumber,
                    endColumn: result.range.endColumn
                }
        };
    }

    /**
     * Releases a perviously created editor
     * @param editorId ID of the editor
     */
    public release(editorId: string) : boolean {
        const editor = this.editors[editorId];
        if (editor) {
            delete this.editors[editorId];
            return true;
        }
        return false;
    }

    /**
     * Gets the IDs of already created editors
     */
    public getEditorIds(): string[] {
        const ids: string[] = [];
        for (const id in this.editors) {
            ids.push(id);
        }
        return ids;
    }

    /**
     * Sets the theme of editors
     * @param themeName Editor them name
     */
    public setTheme(themeName: string) : void {
        monaco.editor.setTheme(themeName);
    }
}

window["MonacoForBlazor"] = new MonacoForBlazorJsInterop();
