using System.Collections.Generic;

namespace MonacoForBlazor.Api.Abstractions
{
    /// <summary>
    /// Represents a Markdonw string
    /// </summary>
    public interface IMarkdownString
    {
        /// <summary>
        /// Value of the string
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Is it a trusted markdown string
        /// </summary>
	    bool? IsTrusted { get; set; }

	    Dictionary<string, UriComponents> Uris { get; set; }
    };
}
