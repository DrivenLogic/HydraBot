using System;
using System.IO;
using System.Threading.Tasks;
using HydraBot.Domain;
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
            File.WriteAllBytes("test" + Guid.NewGuid() + ".jpg", result);

            // Assert
            Assert.True(result.Length > 0);
        }

        //http://ak.channel9.msdn.com/ch9/1cc7/dfd27386-a69b-4e0e-b544-9fbe01351cc7/YOW2011JoeAlbahari_ch9.wmv
    }
}
