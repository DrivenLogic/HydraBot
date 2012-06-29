using HydraBot.DataStructures;
using HydraBot.Domain.impl;
using Xunit;

namespace HydraBot.Tests.Unit
{
    public class BotTests
    {
        [Fact]
        public void BotStartSeedsParseWorkQueue()
        {
            // Arrange
            HyperTextPointer hyperTextPointer = new HyperTextPointer("http://www.flickr.com/search/?q=miranda+kerr&f=hp");

            // Act
            Bot bot = new Bot();
            bot.SeedWorkQueue(hyperTextPointer);

            // Assert
            Assert.True(WorkQueues.DownloadTaskQueue.Count > 0);
        }

        [Fact]
        public void IsTaskRunnerFunctional()
        {
            // Arrange
            HyperTextPointer hyperTextPointer = new HyperTextPointer("http://www.flickr.com/search/?q=miranda+kerr&f=hp");

            // Act
            Bot bot = new Bot();
            bot.SeedWorkQueue(hyperTextPointer);
            bot.ProcessTasks();

        }
    }
}

