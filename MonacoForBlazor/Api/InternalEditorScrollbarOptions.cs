using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Editor scrollbar options
    /// </summary>
    public class InternalEditorScrollbarOptions
    {
        public int ArrowSize { get; set; }
		public ScrollbarVisibility Vertical { get; set; }
        public ScrollbarVisibility Horizontal { get; set; }
		public bool UseShadows { get; set; }
		public bool VerticalHasArrows { get; set; }
		public bool HorizontalHasArrows { get; set; }
		public bool HandleMouseWheel { get; set; }
		public int HorizontalScrollbarSize { get; set; }
		public int HorizontalSliderSize { get; set; }
		public int VerticalScrollbarSize { get; set; }
		public int VerticalSliderSize { get; set; }
		public int MouseWheelScrollSensitivity { get; set; }
		public int FastScrollSensitivity { get; set; }
	}
}
