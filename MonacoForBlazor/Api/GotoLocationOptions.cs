﻿using MonacoForBlazor.Api.Abstractions;

namespace MonacoForBlazor.Api
{
    /// <summary>
    /// Options for goto command
    /// </summary>
    public class GoToLocationOptions : IGoToLocationOptions
    {
        /// <summary>
        /// Control how goto-command work when having multiple results.
        /// Available values: 'peek', 'gotAndPeek', 'goto'
        /// </summary>
        public string Multiple { get; set; }
    }
}
