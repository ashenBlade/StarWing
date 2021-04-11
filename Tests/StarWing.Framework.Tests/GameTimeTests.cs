using System;
using System.Threading;
using NUnit.Framework;
using StarWing.Framework;

namespace Tests.StarWing.Framework.Tests
{
    [TestFixture]
    public class GameTimeTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void CanMeasureTime()
        {
            var gameTime = new GameTimer();
            gameTime.Start();
            var sleepTimeout = TimeSpan.FromMilliseconds(10);
            Thread.Sleep(sleepTimeout);
            var actualTimeout = gameTime.TotalTime;
            Assert.That(actualTimeout, Is.GreaterThanOrEqualTo(sleepTimeout));
        }

        [Test]
        public void CanGetTimeSinceLastUpdate()
        {
            var gameTime = new GameTimer();
            gameTime.Start();
            var sleepTimeout = TimeSpan.FromMilliseconds(10);
            Thread.Sleep(sleepTimeout);
            var actualTimeout = gameTime.SinceLastUpdate;
            Assert.That(actualTimeout, Is.GreaterThanOrEqualTo(sleepTimeout));
        }

        [Test]
        public void TimeSinceLastUpdate_ResetsAfterUpdateMethodCall()
        {
            var gameTime = new GameTimer();
            gameTime.Start();
            var sleepTimeout = TimeSpan.FromMilliseconds(10);
            Thread.Sleep(sleepTimeout);
            gameTime.Update();
            var actualTimeout = gameTime.SinceLastUpdate;
            Assert.That(actualTimeout, Is.LessThanOrEqualTo(sleepTimeout));
        }

        [Test]
        public void TimespanIsEqualToZeroBeforeStart()
        {
            var gameTime = new GameTimer();
            Assert.That(gameTime.SinceLastUpdate, Is.EqualTo(TimeSpan.Zero));
            Assert.That(gameTime.TotalTime, Is.EqualTo(TimeSpan.Zero));
        }
    }
}