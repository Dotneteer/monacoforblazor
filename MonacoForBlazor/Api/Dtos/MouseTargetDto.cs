using MonacoForBlazor.Api.Enums;

namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// DTO for an IMouseTarget object
    /// </summary>
    public class MouseTargetDto
    {
        /// <summary>
        /// ID of cached target element
        /// </summary>
        public string ElementId { get; set; }

        /// <summary>
        /// The target type
        /// </summary>
        public MouseTargetType Type { get; set; }

        /// <summary>
        /// The 'approximate' editor position
        /// </summary>
        public PositionDto Position { get; set; }

        /// <summary>
        /// Desired mouse column (e.g. when position.column gets clamped to text length 
        /// -- clicking after text on a line).
        /// </summary>
        public int MouseColumn { get; set; }

        /// <summary>
        /// The 'approximate' editor range
        /// </summary>
        public RangeDto Range { get; set; }
    }
}
