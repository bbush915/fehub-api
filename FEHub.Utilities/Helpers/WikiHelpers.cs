//-----------------------------------------------------------------------------
// <copyright file="WikiHelpers.cs">
//     Copyright (c) 2020 by Bryan Bush. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------------

using System.Linq;
using System.Text.RegularExpressions;

namespace FEHub.Utilities.Helpers
{
    internal static class WikiHelpers
    {
        public static string Sanitize(string value)
        {
            // NOTE(Bryan) - Line Breaks
            
            value = value.Replace("&amp;#10;", " ");
            value = value.Replace("&lt;br&gt;", " ");
            value = value.Replace("&lt;br /&gt;", " ");
            value = value.Replace("\\n", " ");

            // NOTE(Bryan) - Less Than / Greater Than

            value = value.Replace("&lt;", "<");
            value = value.Replace("&gt;", ">");

            // NOTE(Bryan) - Quotes

            value = value.Replace("&quot;", "\"");

            // NOTE(Bryan) - Links

            value = Regex.Replace(value, @"\[\[([^\]]+)\]\]", match => match.Groups[1].Value.Split('|').Last()) ; 

            return value;
        }
    }
}
