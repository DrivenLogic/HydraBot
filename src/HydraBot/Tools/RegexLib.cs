using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace HydraBot.Tools
{
    /// <summary>
    /// Static class to contain compiled regex.
    /// TODO: Methods that return Lists could be used to implement multipass. 
    /// </summary>
    public static class RegexLib
    {
        public static Regex HyperLinkRegex()
        {
            Regex hyperLinkRegex = new Regex(

                //basic example for links with extensions
                //@"(?<=href="")([^""']*?.)?(\.html|\.htm|\.php)(?:/?)([^""']*?)",

                //This regex deals with pages that are badly formed and donot use quotes around links, may not match all links.
                //@"(?<=href\=).*?(\.html|\.php|\.htm|\.pl|\.js)(?:/?)([^>""']*)",

                //only matches querystirngs containing "2005" or "2006"
                //@"([^""']*?.)?(\.js|\.html|\.php)(?:/?)([^""']*?)(2006|2005)(?:)([^""']*)", 

                // for newer REST style resorces that dont have extension for example: /order/34/ 
                // this will not match any link with a . (period contained within)
                @"(?<=href="")([^""'\.]*)(?=[""'])",

                RegexOptions.IgnoreCase
                | RegexOptions.Multiline
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );

            return hyperLinkRegex;
        }

        public static Regex BinaryRegex()
        {
            Regex binaryRegex = new Regex(

                // Works well enough in most cases. 
                @"(?<=src\=\""|href\=\"")[^""']*.(\.jpg|\.wmv|\.pdf|.zip)(?:/?[^""']*)",

                // this is a bit rough, no positive look behind for src or for href
                //@"[^""']*.(\.jpg|\.mpeg|\.mpg|\.wmv)(?:/?[^""']*)",

                // Shoddy non quoted links - might well be shoddy 
                //@"(?<=href\=).*?(\.wmv|\.zip)(?:/?)([^>""']*)",

                // only match with the term 'Large' in the path. 
                //@"(?<=src\=\""|href\=\"")[^""']*(large).*(\.jpg|\.mpg|\.wmv)(?:/?[^""']*)", 

                //only matches querystirngs containing "2005" or "2006"
                //@"([^""']*.)?(\.jpg|\.mpeg|\.mpg|\.wmv)(?:/?)([^""']*)(2005|2006)(?:/?)([^""']*)",

                RegexOptions.IgnoreCase
                | RegexOptions.Multiline
                | RegexOptions.IgnorePatternWhitespace
                | RegexOptions.Compiled
                );

            return binaryRegex;
        }
    }
}

