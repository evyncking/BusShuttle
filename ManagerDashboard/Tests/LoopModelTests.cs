using Xunit;
using ManagerDashboard.Models;

namespace ManagerDashboard.Tests
{
    public class LoopModelTests
    {
        [Fact]
        public void CanCreateLoop()
        {
            var loop = new LoopModel { LoopName = "TestLoop" };

            Assert.Equal("TestLoop", loop.LoopName);
        }

        [Fact]
        public void CanUpdateLoop()
        {
            var loop = new LoopModel { LoopName = "Blue" };

            loop.LoopName = "Green";

            Assert.Equal("Green", loop.LoopName);
        }

        [Fact]
        public void CanDeleteLoop()
        {
            var loop = new LoopModel { LoopName = "TestLoop" };

            _dbContext.Loops.Remove(loop);

            Assert.DoesNotContain(loop, _dbContext.Loops);
        }
    }
    }
}