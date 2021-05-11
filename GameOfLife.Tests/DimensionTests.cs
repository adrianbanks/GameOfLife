using NUnit.Framework;

namespace adrianbanks.GameOfLife.Tests
{
    [TestFixture]
    public sealed class DimensionTests
    {
        [Test]
        public void CreateUsesDefaultSize_WhenSizeIsNotSpecified()
        {
            var dimension = Dimension.Create(null, null);
            Assert.That(dimension.Width, Is.Not.Null);
            Assert.That(dimension.Height, Is.Not.Null);
        }

        [Test]
        public void CreateUsesOriginalSize_WhenSizeIsNotSpecified()
        {
            var dimension = Dimension.Create(new Dimension(10, 20), null, null);
            Assert.That(dimension.Width, Is.EqualTo(10));
            Assert.That(dimension.Height, Is.EqualTo(20));
        }

        [TestCase(50, 60)]
        [TestCase(50, null)]
        [TestCase(null, 60)]
        public void Create_HonoursSpecifiedSize(int? width, int? height)
        {
            var dimension = Dimension.Create(new Dimension(10, 20), width, height);
            Assert.That(dimension.Width, Is.EqualTo(width ?? 10));
            Assert.That(dimension.Height, Is.EqualTo(height ?? 20));
        }

        [Test]
        public void Contains_AtCorners()
        {
            var dimension = new Dimension(4, 4);
            Assert.That(dimension.Contains(new(0, 0)), Is.True);
            Assert.That(dimension.Contains(new(3, 0)), Is.True);
            Assert.That(dimension.Contains(new(0, 3)), Is.True);
            Assert.That(dimension.Contains(new(3, 3)), Is.True);
        }

        [Test]
        public void Contains_WithinBounds()
        {
            var dimension = new Dimension(4, 4);
            Assert.That(dimension.Contains(new(2, 0)), Is.True);
            Assert.That(dimension.Contains(new(1, 3)), Is.True);
            Assert.That(dimension.Contains(new(3, 2)), Is.True);
            Assert.That(dimension.Contains(new(0, 1)), Is.True);
        }

        [Test]
        public void Contains_OutsideBounds()
        {
            var dimension = new Dimension(4, 4);
            Assert.That(dimension.Contains(new(-1, 0)), Is.False);
            Assert.That(dimension.Contains(new(0, -1)), Is.False);
            Assert.That(dimension.Contains(new(4, 2)), Is.False);
            Assert.That(dimension.Contains(new(0, 4)), Is.False);
        }
    }
}
