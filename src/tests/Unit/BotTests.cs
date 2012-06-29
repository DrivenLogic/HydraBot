using HydraBot.DataStructures;
using HydraBot.Domain;
using Xunit;

namespace HydraBot.Tests.Unit
{
    public class BotTests
    {
        [Fact]
        public void BotStartSeedsParseWorkQueue()
        {
            // Arrange
            Bot bot = new Bot();

            // Act
            bot.StartLocation("http://www.flickr.com/search/?q=miranda+kerr&f=hp");

            // Assert
            Assert.True(WorkQueues.DownloadTaskQueue.Count > 0);
        }

        [Fact]
        public void IsTaskRunnerFunctional()
        {
            // Arrange
            Bot bot = new Bot();
            
            // Act
            bot.StartLocation("http://www.flickr.com/search/?q=miranda+kerr&f=hp");
            bot.ProcessTasks();
        }
    }
}

