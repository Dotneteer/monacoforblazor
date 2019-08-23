(function () {
    const monacoForBlazor = "MonacoForBlazor";

    const extensionObject = {
        // --- Monaco editor interop methods
        editorInitialize: (editorId, ops) => {
            console.log(JSON.stringify(ops, null, 2));
            var element = document.getElementById(editorId);
            var child = element.lastElementChild;
            while (child) {
                element.removeChild(child);
                child = element.lastElementChild;
            }
            console.log(`Creating ${editorId}`);
            monaco.editor.create(element, {
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
        },

        setTheme: (themeName) => { monaco.editor.setTheme(themeName); },

        // --- Pointer interop methods
        setPointerCapture: (element, pointerId) => {
            if (element) {
                element.setPointerCapture(pointerId);
                return true;
            } else {
                return false;
            }
        },

        releasePointerCapture: function (element, pointerId) {
            if (element) {
                element.releasePointerCapture(pointerId);
                return true;
            } else {
                return false;
            }
        },

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