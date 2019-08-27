var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
/**
 * Encapsule the Monace interop API
 */
var MonacoForBlazorJsInterop = /** @class */ (function () {
    /**
     * Initializes the API
     */
    function MonacoForBlazorJsInterop() {
        // --- We keep initialized editors here
        this.editors = {};
        // --- We keep cached objects here
        this._objectCache = {};
        this.EXPIRATION_TIMEOUT = 10000;
        this._objectSeqNo = 0;
        this._setExpirationScan();
    }
    /**
     * Get the editor with the specified ID
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype._getEditor = function (editorId) {
        return this.editors[editorId];
    };
    /**
     * Ensures that the specified editor has been created
     * @param editorId ID of the editor
     *
     * Throws an error if the editor has not been created, or
     * already disposed.
     */
    MonacoForBlazorJsInterop.prototype._ensureEditor = function (editorId) {
        var editor = this._getEditor(editorId);
        if (!editor) {
            throw new Error("Cannot find editor: " + editorId);
        }
        return editor;
    };
    /**
     * Adds an item to the cache
     * @param item Entry to add to the cache
     * @param type Type of cache entry
     */
    MonacoForBlazorJsInterop.prototype._addToCache = function (item, type) {
        var newId = (this._objectSeqNo++).toString();
        this._objectCache[newId] = {
            item: item,
            type: type,
            expires: Date.now() + this.EXPIRATION_TIMEOUT
        };
        return newId;
    };
    /**
     * Removes the specified item from the cache
     * @param objId ID of object to remove
     */
    MonacoForBlazorJsInterop.prototype._removeFromCache = function (objId) {
        delete this._objectCache[objId];
    };
    /**
     * Gets the specified item from the cache
     * @param objId Object ID
     * @param type Object type
     */
    MonacoForBlazorJsInterop.prototype.getFromCache = function (objId, type) {
        var inCache = this._objectCache[objId];
        if (!inCache)
            return undefined;
        if (!inCache.type || inCache.type !== type)
            return undefined;
        return inCache.item;
    };
    /**
     * Removes expired items from the cache
     */
    MonacoForBlazorJsInterop.prototype._removeExpiredItems = function () {
        var now = Date.now();
        var count = 0;
        for (var key in this._objectCache) {
            var expired = this._objectCache[key].expires < now;
            if (expired) {
                delete this._objectCache[key];
            }
            else {
                count++;
            }
        }
    };
    /**
     * Sets up the interval to remove expired items from the cache
     */
    MonacoForBlazorJsInterop.prototype._setExpirationScan = function () {
        var _this = this;
        setInterval(function () {
            _this._removeExpiredItems();
            _this._setExpirationScan;
        }, this.EXPIRATION_TIMEOUT);
    };
    /**
     * Creates a new editor and initializes it
     * @param editorId ID of the new editor
     * @param ops Editor construction options
     */
    MonacoForBlazorJsInterop.prototype.editorInitialize = function (editorId, ops) {
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
    };
    /**
     * Apply the same font settings as the editor to target.
     * @param editorId ID of the editor
     * @param target Target HTML element
     */
    MonacoForBlazorJsInterop.prototype.applyFontInfo = function (editorId, target) {
        var editor = this._ensureEditor(editorId);
        editor.applyFontInfo(target);
    };
    /**
     * Disposes the specified editor
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.dispose = function (editorId) {
        var editor = this.editors[editorId];
        if (editor) {
            delete this.editors[editorId];
            editor.dispose();
            return true;
        }
        return false;
    };
    /**
     * Sets the focus to the specified editor
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.focus = function (editorId) {
        var editor = this._ensureEditor(editorId);
        editor.focus();
    };
    /**
     * Returns the editor's dom node
     * @param editorId ID of the editor
    */
    MonacoForBlazorJsInterop.prototype.getDomNode = function (editorId) {
        var editor = this._ensureEditor(editorId);
        var element = editor.getDomNode();
        return this._addToCache(element, "HTMLElement");
    };
    /**
     * Gets the type of the editor
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getConfiguration = function (editorId) {
        var editor = this._ensureEditor(editorId);
        var result = editor.getConfiguration();
        console.log(JSON.stringify(result, null, 2));
        return __assign({}, result, { contribInfo: __assign({}, result.contribInfo, { quickSuggestions: result.contribInfo.quickSuggestions === true
                    || result.contribInfo.quickSuggestions === false
                    ? result.contribInfo.quickSuggestions : null, quickSuggestionOptions: result.contribInfo.quickSuggestions === true
                    || result.contribInfo.quickSuggestions === false
                    ? null : result.contribInfo.quickSuggestions }) });
    };
    /**
     * Gets the type of the editor
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getEditorType = function (editorId) {
        var editor = this._ensureEditor(editorId);
        return editor.getEditorType();
    };
    /**
     * Get the scrollHeight of the editor's viewport.
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getScrollHeight = function (editorId) {
        var editor = this._ensureEditor(editorId);
        return editor.getScrollHeight();
    };
    /**
     * Get the scrollLeft of the editor's viewport.
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getScrollLeft = function (editorId) {
        var editor = this._ensureEditor(editorId);
        return editor.getScrollLeft();
    };
    /**
     * Get the scrollTop of the editor's viewport.
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getScrollTop = function (editorId) {
        var editor = this._ensureEditor(editorId);
        return editor.getScrollTop();
    };
    /**
     * Get the scrollWidth of the editor's viewport.
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getScrollWidth = function (editorId) {
        var editor = this._ensureEditor(editorId);
        return editor.getScrollWidth();
    };
    /**
     * Get the visible position.
     * @param editorId ID of the editor
     * @param position Position to get the info about
     */
    MonacoForBlazorJsInterop.prototype.getScrolledVisiblePosition = function (editorId, position) {
        var editor = this._ensureEditor(editorId);
        return editor.getScrolledVisiblePosition(position);
    };
    /**
     * Returns the primary selection of the editor.
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getSelection = function (editorId) {
        var editor = this._ensureEditor(editorId);
        return editor.getSelection();
    };
    /**
     * Returns all the selections of the editor.
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getSelections = function (editorId) {
        var editor = this._ensureEditor(editorId);
        return editor.getSelections();
    };
    /**
     * Returns all the selections of the editor.
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.getTargetAtClientPoint = function (editorId, clientX, clientY) {
        var editor = this._ensureEditor(editorId);
        var result = editor.getTargetAtClientPoint(clientX, clientY);
        if (!result)
            return null;
        var elementId = this._addToCache(result.element, "HTMLElement");
        return {
            elementId: elementId,
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
    };
    /**
     * Releases a perviously created editor
     * @param editorId ID of the editor
     */
    MonacoForBlazorJsInterop.prototype.release = function (editorId) {
        var editor = this.editors[editorId];
        if (editor) {
            delete this.editors[editorId];
            return true;
        }
        return false;
    };
    /**
     * Gets the IDs of already created editors
     */
    MonacoForBlazorJsInterop.prototype.getEditorIds = function () {
        var ids = [];
        for (var id in this.editors) {
            ids.push(id);
        }
        return ids;
    };
    /**
     * Sets the theme of editors
     * @param themeName Editor them name
     */
    MonacoForBlazorJsInterop.prototype.setTheme = function (themeName) {
        monaco.editor.setTheme(themeName);
    };
    return MonacoForBlazorJsInterop;
}());
window["MonacoForBlazor"] = new MonacoForBlazorJsInterop();
//# sourceMappingURL=monaco-interop.js.map