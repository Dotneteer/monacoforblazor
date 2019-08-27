namespace MonacoForBlazor.Api.Abstractions
{
    public interface IFontInfo
    {
        bool CanUseHalfwidthRightwardsArrow { get; }
        string FontFamily { get; }
        double FontSize { get; }
        string FontWeight { get; }
        bool IsMonospace { get; }
        bool IsTrusted { get; }
        int LetterSpacing { get; }
        int LineHeight { get; }
        double MaxDigitWidth { get; }
        double SpaceWidth { get; }
        double TypicalFullwidthCharacterWidth { get; }
        double TypicalHalfwidthCharacterWidth { get; }
        int ZoomLevel { get; set; }
    }
}