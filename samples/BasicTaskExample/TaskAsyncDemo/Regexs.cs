using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TaskAsyncDemo
{
    public class Regexs
    {
         public static Regex LinksRegex()
         {
             Regex linksRegex = new Regex(

             
                 //@"(?<=href="")([^""']*?.)?(\.html|\.htm|\.php)(?:/?)([^""']*?)", // Working MN

                 // for newer style resorces that dont have extension for example: /order/34/ 
                 // this will not match any link with a . (period contained within)
                 @"(?<=href="")([^""'\.]*)(?=[""'])",

                 RegexOptions.IgnoreCase
                 //| RegexOptions.Multiline
                 //| RegexOptions.IgnorePatternWhitespace
                 | RegexOptions.Compiled
                 );

             ////This regex deals with pages that are badly formed and donot use quotes around links, may not match all links.
             //Regex DirtyLinksNoQuotes = new Regex(

             //    @"(?<=href\=).*?(\.html|\.php|\.htm|\.pl|\.js)(?:/?)([^>""']*)",

             //    RegexOptions.IgnoreCase
             //    //| RegexOptions.Multiline
             //    //| RegexOptions.IgnorePatternWhitespace
             //    | RegexOptions.Compiled
             //    );

             //This Regex is for correly quoted links, works with javascript args
             //.2008.08.17.1223
             // v2 ([^""']*?.)?(\.html|\.php|\.htm|\.pl|\.js)(?:/?)([^""']*?)
             // v1   @"([^""']*?.)?(\.html|\.php|\.htm|\.pl|\.js)(?:/?)([^""']*?)(?:)([^""']*)",

             //This regex deals with pages that are badly formed and donot use quotes around links, may not match all links.
             //.2008.08.17.1158
             //(?<=href\=).*?(\.html|\.php|\.htm|\.pl|\.js)(?:/?)([^>""']*)

             //only matches querystirngs containing "2005" or "2006"
             //@"([^""']*?.)?(\.js|\.html|\.php)(?:/?)([^""']*?)(2006|2005)(?:)([^""']*)", 

             return linksRegex;
         }

        public static Regex BinaryRegex()
		{
			Regex binaryRegex = new Regex(

                // Normal links
                @"(?<=src\=\""|href\=\"")[^""']*.(\.jpg|\.gif|.png)(?:/?[^""']*)", // working WW
                
                // this is a bit rough, no positive look behind for src or for href
                //@"[^""']*.(\.jpg|\.mpeg|\.mpg|\.wmv)(?:/?[^""']*)",

                // Shoddy non quoted links - might well be shoddy - AN
                //@"(?<=href\=).*?(\.wmv|\.zip)(?:/?)([^>""']*)",

                // only match with the term 'Large' in the path. 
                //@"(?<=src\=\""|href\=\"")[^""']*(large).*(\.jpg|\.mpg|\.wmv)(?:/?[^""']*)", 
                
                //only matches querystirngs containing "2005" or "2006"
                //@"([^""']*.)?(\.jpg|\.mpeg|\.mpg|\.wmv)(?:/?)([^""']*)(2005|2006)(?:/?)([^""']*)",
         
                //another attempt at removing bogus links where a resource has been added to another type of 
                //attribute
                //(?<=src\=\"|href\=\")[^""']*.(\.jpg|\.mpeg|\.mpg|\.wmv)(?:/?[^""']*) 

				RegexOptions.IgnoreCase
				| RegexOptions.Multiline
				| RegexOptions.IgnorePatternWhitespace
				| RegexOptions.Compiled
				);

            return binaryRegex;
		}
	
    }
}
