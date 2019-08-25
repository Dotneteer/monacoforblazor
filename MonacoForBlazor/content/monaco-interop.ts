class MonacoForBlazorJsInterop {
    // --- We keep initialized editors here
    private readonly editors = {};

    // --- Helper functions used in extension methods
    private getEditor(editorId) {
        return this.editors[editorId];
    }

    // --- Throws an error, if editor not found
    private ensureEditor(editorId) {
        var editor = this.getEditor(editorId);
        if (!editor) {
            throw new Error("Cannot find editor: " + editorId);
        }
        return editor;
    }

    // --- Creates and initializes a new editor
    public editorInitialize(editorId, ops) {
        var element = document.getElementById(editorId);
        var child = element.lastElementChild;
        while (child) {
            element.removeChild(child);
            child = element.lastElementChild;
        }
        var newEditor = monaco.editor.create(element, {
            acceptSuggestionOnCommitCharacter: ops.acceptSuggestionOnCommitCharacter,
            acceptSuggestionOnEnter: ops.acceptSuggestionOnEnter,
            accessibilityHelpUrl: ops.accessibilityHelpUrl,
            accessibilitySupport: ops.accessibilitySupport,
            ariaLabel: ops.AriaLabel,
            autoClosingBrackets: ops.autoClosingBrackets,
            autoClosingQuotes: ops.autoClosingQuotes,
            autoIndent: ops.autoIndent,
            autoSurround: ops.autoSurround,
            automaticLayout: ops.automaticLayout,
            codeActionsOnSave: ops.codeActionsOnSave,
            codeActionsOnSaveTimeout: ops.CodeActionsOnSaveTimeout,
            codeLens: ops.codeLens,
            colorDecorators: ops.colorDecorators,
            contextmenu: ops.contextmenu,
            copyWithSyntaxHighlighting: ops.CopyWithSyntaxHighlighting,
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
        this.editors[editorId] = newEditor;
    }

    // --- Apply the same font settings as the editor to target.
    applyFontInfo(editorId: string, target: HTMLElement) {
        const editor = this.ensureEditor(editorId);
        editor.applyFontInfo(target);
    }

    // --- Disposes the specified editor
    dispose(editorId: string) {
        const editor = this.editors[editorId];
        if (editor) {
            delete this.editors[editorId];
            editor.dispose();
            return true;
        }
        return false;
    }

    // --- Sets the focus to the specified editor
    focus(editorId: string) {
        const editor = this.ensureEditor(editorId);
        editor.focus();
    }

    // --- Gets the type of the editor
    getEditorType(editorId: string) {
        const editor = this.ensureEditor(editorId);
        return editor.getEditorType();
    }

    // --- Get the scrollHeight of the editor's viewport.
    getScrollHeight(editorId: string) {
        const editor = this.ensureEditor(editorId);
        return editor.getScrollHeight();
    }

    // --- Get the scrollLeft of the editor's viewport.
    getScrollLeft(editorId: string) {
        const editor = this.ensureEditor(editorId);
        return editor.getScrollLeft();
    }

    // --- Get the scrollTop of the editor's viewport.
    getScrollTop(editorId: string) {
        const editor = this.ensureEditor(editorId);
        return editor.getScrollTop();
    }

    // --- Get the scrollWidth of the editor's viewport.
    getScrollWidth(editorId: string) {
        const editor = this.ensureEditor(editorId);
        return editor.getScrollWidth();
    }

    // --- Get the visible position. 
    getScrolledVisiblePosition(editorId: string, position) {
        const editor = this.ensureEditor(editorId);
        return editor.getScrolledVisiblePosition(position);
    }

    // --- Returns the primary selection of the editor.
    getSelection(editorId: string) {
        const editor = this.ensureEditor(editorId);
        return editor.getSelection();
    }

    // --- Returns all the selections of the editor.
    getSelections(editorId: string) {
        const editor = this.ensureEditor(editorId);
        return editor.getSelections();
    }

    // --- Releases a perviously created editor
    release(editorId) {
        const editor = this.editors[editorId];
        if (editor) {
            delete this.editors[editorId];
            return true;
        }
        return false;
    }

    // --- Gets the IDs of already created editors
    getEditorIds() {
        const ids = [];
        for (const id in this.editors) {
            ids.push(id);
        }
        return ids;
    }

    setTheme(themeName) {
        monaco.editor.setTheme(themeName);
    }
}

window["MonacoForBlazor"] = new MonacoForBlazorJsInterop();
