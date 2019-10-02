using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api.Abstractions
{
    public interface IEditorWrappingInfo
    {
        bool InDiffEditor { get; }
        bool IsDominatedByLongLines { get; }
        bool IsViewportWrapping { get; }
        bool IsWordWrapMinified { get; }
        string WordWrapBreakAfterCharacters { get; }
        string WordWrapBreakBeforeCharacters { get; }
        string WordWrapBreakObtrusiveCharacters { get; }
        int WrappingColumn { get; }
        WrappingIndent WrappingIndent { get; }
    }
}