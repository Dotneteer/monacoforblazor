using MonacoForBlazor.Api.Abstractions;

namespace MonacoForBlazor.Api.Dtos
{
    /// <summary>
    /// Provides information about the editor font
    /// </summary>
    public class FontInfoDto : IFontInfo
    {
        public bool IsTrusted { get; set; }
        public bool IsMonospace { get; set; }
        public double TypicalHalfwidthCharacterWidth { get; set; }
        public double TypicalFullwidthCharacterWidth { get; set; }
        public bool CanUseHalfwidthRightwardsArrow { get; set; }
        public double SpaceWidth { get; set; }
        public double MaxDigitWidth { get; set; }
        public int ZoomLevel { get; set; }
        public string FontFamily { get; set; }
        public string FontWeight { get; set; }
        public double FontSize { get; set; }
        public int LineHeight { get; set; }
        public int LetterSpacing { get; set; }
    }
}
