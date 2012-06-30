using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HydraBot.Domain;
using Xunit;

namespace HydraBot.Tests.Integration
{
    public class HttpParserTests
    {
        [Fact]
        public async Task ParserCanParseSampleMarkup()
        {
            //arrange
            HttpParser parser = new HttpParser();
            IEnumerable<Match> result = await parser.Parse(File.ReadAllText("Integration//SampleMarkup.html"));

            //act
            result.ToList().ForEach(r => Console.WriteLine(r.Value));

            //assert
            // yeah yeah could assert a known match collection length.

        }
    }
}
