using System;
using System.Security.Cryptography.X509Certificates;
using NUnit.Framework;
using StarWing.Framework.Primitives;

namespace Tests.StarWing.Framework.Tests
{
    [TestFixture]
    public class Vector2DTests
    {
        private Random _random = new Random();

        public Vector2DTests()
        {
        }

        // [min - 1; max + 1]
        private float GetRandomFloat(int min = -100, int max = 100)
            => _random.Next(min, max) + (float) _random.NextDouble();

        // [min - 1; max + 1]
        // min, max - coordinates of vector not including floating point
        private Vector2D GetRandomVector(int min = -100, int max = 100) =>
            new Vector2D(GetRandomFloat(min, max), GetRandomFloat(min, max));

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDown()
        {

        }

        [TestCase(0.0f, 0.0f, 0.0f, 0.0f, true)]
        public void CanCompareVectors(float xFirst, float yFirst, float xSecond, float ySecond, bool expected)
        {
            var (first, second) = ( new Vector2D(xFirst, yFirst), new Vector2D(xSecond, ySecond) );
            Assert.AreEqual(expected, first == second);
        }

        [TestCase(0.0f, 0.0f, 1.0f, 1.0f, 1.0f, 1.0f)]
        [TestCase(0.1f, 0.0f, 1.0f, 1.0f, 1.1f, 1.0f)]
        [TestCase(1.0f, -1.0f, 1.0f, 1.0f, 2.0f, 0.0f)]
        [TestCase(1.0f, -1.0f, 1.0f, 1.0f, 2.0f, 0.0f)]
        public void CanAddVectors(float xFirst, float yFirst, float xSecond, float ySecond, float xExpected, float yExpected)
        {
            var first = new Vector2D(xFirst, yFirst);
            var second = new Vector2D(xSecond, ySecond);
            var actual = first + second;
            var expected = new Vector2D(xExpected, yExpected);
            Assert.AreEqual(expected, actual);
        }
    }
}