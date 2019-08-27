using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Editor wrapping information
    /// </summary>
    public class EditorWrappingInfo
    {
        public bool InDiffEditor { get; set; }
		public bool IsDominatedByLongLines { get; set; }
		public bool IsWordWrapMinified { get; set; }
		public bool IsViewportWrapping { get; set; }
		public int WrappingColumn { get; set; }
		public WrappingIndent WrappingIndent { get; set; }
        public string WordWrapBreakBeforeCharacters { get; set; }
		public string WordWrapBreakAfterCharacters { get; set; }
		public string WordWrapBreakObtrusiveCharacters { get; set; }
	}
}
