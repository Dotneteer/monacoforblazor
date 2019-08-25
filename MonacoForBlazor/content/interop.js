(function () {
    const monacoForBlazor = "MonacoForBlazor";

    // --- Store the sequence number of objects here
    let objectSeqNo = 0;

    // --- We keep initialized editors here
    const editors = {};

    // --- Helper functions used in extension methods
    function getEditor(editorId) {
        return editors[editorId];
    }

    // --- Throws an error, if editor not found
    function ensureEditor(editorId) {
        var editor = getEditor(editorId);
        if (!editor) {
            throw new Error("Cannot find editor: " + editorId);
        }
        return editor;
    }

    // --- We keep cached objects here
    const objectCache = {};
    const expirationTimeout = 10000;
    setExpirationScan();
    
    // --- Adds an element to the cache with creation date
    function addToCache(obj, type) {
        objectCache[objectSeqNo++] = {
            item: obj,
            type,
            created: new Date() + expirationTimeOut
        };
    }

    // --- Removes the specified item from the cache
    function removeFromCache(objId) {
        delete objectCache[objId];
    }

    // --- Gets the specified item from the cache
    function getFromCache(objId, type) {
        const inCache = objectCache[objId];
        if (!inCache) return;
        if (!inCache.type || inCache.type !== type) return;
        return inCache.item;
    }

    // --- Removes expired items from the cache
    function removeExpiredItems(expirationInMs) {
        var now = Date.now();
        for (var key in objectCache) {
            var expired = objectCache[key].created + expirationInMs < now;
            if (expired) {
                delete objectCache[key];
            }
        }
    }

    // --- Sets up the interval to remove expired items from the cache
    function setExpirationScan() {
        setInterval(() => {
            console.log("Expiration scan");
            removeExpiredItems();
            setExpirationScan;
        }, expirationTimeout);
    }

    // --- This object holds the extension methods
    const extensionObject = {

        // --- Creates and initializes a new editor
        editorInitialize: (editorId, ops) => {
            var element = document.getElementById(editorId);
            var child = element.lastElementChild;
            while (child) {
                element.removeChild(child);
                child = element.lastElementChild;
            }
            var newEditor =  monaco.editor.create(element, {
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
                disableMonospaceopsimizations: ops.disableMonospaceopsimizations,
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
            editors[editorId] = newEditor;
        },

        // --- Apply the same font settings as the editor to target.
        applyFontInfo: (editorId, target) => {
            const editor = ensureEditor(editorId);
            editor.applyFontInfo(target);
        },

        // --- Disposes the specified editor
        dispose: (editorId) => {
            const editor = editors[editorId];
            if (editor) {
                delete editors[editorId];
                editor.dispose();
                return true;
            }
            return false;
        },

        // --- Sets the focus to the specified editor
        focus: (editorId) => {
            const editor = ensureEditor(editorId);
            editor.focus();
        },

        // --- Gets the type of the editor
        getEditorType: (editorId) => {
            const editor = ensureEditor(editorId);
            return editor.getEditorType();
        },

        // --- Get the scrollHeight of the editor's viewport.
        getScrollHeight: (editorId) => {
            const editor = ensureEditor(editorId);
            return editor.getScrollHeight();
        },

        // --- Get the scrollLeft of the editor's viewport.
        getScrollLeft: (editorId) => {
            const editor = ensureEditor(editorId);
            return editor.getScrollLeft();
        },

        // --- Get the scrollTop of the editor's viewport.
        getScrollTop: (editorId) => {
            const editor = ensureEditor(editorId);
            return editor.getScrollTop();
        },

        // --- Get the scrollWidth of the editor's viewport.
        getScrollWidth: (editorId) => {
            const editor = ensureEditor(editorId);
            return editor.getScrollWidth();
        },

        // --- Get the visible position. 
        getScrolledVisiblePosition: (editorId, position) => {
            const editor = ensureEditor(editorId);
            return editor.getScrolledVisiblePosition(position);
        },

        // --- Returns the primary selection of the editor.
        getSelection: (editorId) => {
            const editor = ensureEditor(editorId);
            return editor.getSelection();
        },

        // --- Returns all the selections of the editor.
        getSelections: (editorId) => {
            const editor = ensureEditor(editorId);
            return editor.getSelections();
        },

        // --- Releases a perviously created editor
        release: (editorId) => {
            const editor = editors[editorId];
            if (editor) {
                delete editors[editorId];
                return true;
            }
            return false;
        },

        // --- Gets the IDs of already created editors
        getEditorIds: () => {
            const ids = [];
            for (const id in editors) {
                ids.push(id);
            }
            return ids;
        },

        setTheme: (themeName) => { monaco.editor.setTheme(themeName); },
    };

    if (typeof window !== 'undefined' && !window[monacoForBlazor]) {
        window[monacoForBlazor] = {
            ...extensionObject
        };
    } else {
        window[monacoForBlazor] = {
            ...window[monacoForBlazor],
            ...extensionObject
        };
    }
})();