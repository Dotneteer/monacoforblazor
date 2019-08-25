using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Options for rendering a model decoration in the overview ruler.
    /// </summary>
    public class ModelDecorationOverviewRulerOptions: ModelDecorationOptions
    {
        /// <summary>
        /// The position in the overview ruler.
        /// </summary>
        public OverviewRulerLane Position { get; set; }
    }
}
