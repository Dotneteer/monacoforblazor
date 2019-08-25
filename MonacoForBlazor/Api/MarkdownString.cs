using MonacoForBlazor.Api.Abstractions;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MonacoForBlazor.Api
{
    public class MarkdownString : IMarkdownString
    {
        /// <summary>
        /// Value of the string
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Is it a trusted markdown string
        /// </summary>
	    public bool? IsTrusted { get; set; }

        public Dictionary<string, UriComponents> Uris { get; set; }

        public MarkdownString(string value = "")
        {
            Value = value;
        }

        public MarkdownString AppendText(string value)
        {
            // escape markdown syntax tokens: http://daringfireball.net/projects/markdown/syntax#backslash
            Value += new Regex("[\\`*_{ }[\\]()#+\\-.!]").Replace(value, "\\$&");
		    return this;
        }

        public MarkdownString AppendMarkdown(string value)
        {
            Value += value;
		    return this;
        }

        public MarkdownString AppendCodeblock(string langId, string code)
        {
            Value += "\n```";
            Value += langId;
            Value += "\n";
            Value += code;
            Value += "\n```\n";
		    return this;
        }
    }
}
