using MonacoForBlazor.Api.Abstractions;

namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// Configuration options for parameter hints
    /// </summary>
    public class EditorParameterHintOptionsDto : IEditorParameterHintOptions
    {
        /// <summary>
        /// Enable parameter hints.
        /// Defaults to true.
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Enable cycling of parameter hints.
        /// Defaults to false.
        /// </summary>        
        public bool Cycle { get; set; } = false;
    }
}
