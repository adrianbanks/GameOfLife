using System.Linq;
using NUnit.Framework;

namespace adrianbanks.GameOfLife.Tests
{
    [TestFixture]
    public sealed class GridNavigationTests
    {
        [Test]
        public void AllCells()
        {
            var allCells = GridNavigation.AllCells(new Dimension(2, 2)).ToList();

            var expectedCells = new Coordinate[] { new(0, 0), new(0, 1), new(1, 0), new(1, 1) };
            Assert.That(allCells, Is.EquivalentTo(expectedCells));
        }

        [Test]
        public void SurroundingCells()
        {
            var surroundingCells = GridNavigation.SurroundingCells(new(2, 2)).ToList();

            var expectedCells = new Coordinate[] { new(1, 1), new(2, 1), new(3, 1), new(1, 2), new(3, 2), new(1, 3), new(2, 3), new(3, 3) };
            Assert.That(surroundingCells, Is.EquivalentTo(expectedCells));
        }
    }
}
