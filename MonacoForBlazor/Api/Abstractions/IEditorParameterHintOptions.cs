namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// Represents the parameter hint options of the editor
    /// </summary>
    public interface IEditorParameterHintOptions
    {
        /// <summary>
        /// Enable cycling of parameter hints.
        /// </summary>
        bool Cycle { get; set; }

        /// <summary>
        /// Enable parameter hints.
        /// </summary>
        bool Enabled { get; set; }
    }
}