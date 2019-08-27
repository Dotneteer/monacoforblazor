namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Minimap option properties
    /// </summary>
    public class InternalEditorMinimapOptions
    {
        public bool Enabled { get; set; }
		public string Side { get; set; }
		public string ShowSlider { get; set; }
		public bool RenderCharacters { get; set; }
		public int MaxColumn { get; set; }
	}
}
