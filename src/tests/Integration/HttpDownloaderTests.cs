using System.IO;
using System.Threading.Tasks;
using HydraBot.Domain.impl;
using Xunit;

namespace HydraBot.Tests.Integration
{
    public class HttpDownloaderTests
    {
        [Fact]
        public async Task GetBinaryAsync()
        {
            // Arrange 
            HttpDownloader httpDownloader = new HttpDownloader();

            // Act
            byte[] result = await httpDownloader.GetBinary("http://farm4.staticflickr.com/3492/4045844654_fa980e2591.jpg");

            // test runner waits for the result...
            File.WriteAllBytes("test.jpg",result);

            // Assert
            Assert.True(result.Length > 0);
        }
    }
}
