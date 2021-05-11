using NUnit.Framework;

namespace adrianbanks.GameOfLife.Tests
{
    [TestFixture]
    public sealed class CoordinateTests
    {
        [Test]
        public void NewCells_HaveNoAge()
        {
            var cell = new Coordinate(1, 1);
            Assert.That(cell.Age, Is.EqualTo(0));
        }

        [Test]
        public void CellsCreatedFromOthers_HaveAge()
        {
            var original = new Coordinate(1, 1);
            var cell = new Coordinate(original);
            Assert.That(cell.Age, Is.EqualTo(1));
        }

        [Test]
        public void CellsCreatedFromOthers_HaveSamePosition()
        {
            var original = new Coordinate(1, 2);
            var cell = new Coordinate(original);
            Assert.That(cell.X, Is.EqualTo(1));
            Assert.That(cell.Y, Is.EqualTo(2));
        }

        [Test]
        public void CellEquality_UsesPosition()
        {
            var x = new Coordinate(1, 2);
            var y = new Coordinate(1, 2);
            Assert.That(x.Equals(y), Is.True);
            Assert.That(y.Equals(x), Is.True);
        }

        [Test]
        public void CellEquality_DoesNotUseAge()
        {
            var x = new Coordinate(1, 2);
            var y = new Coordinate(x);
            Assert.That(x.Age, Is.EqualTo(0));
            Assert.That(y.Age, Is.EqualTo(1));
            Assert.That(x.Equals(y), Is.True);
            Assert.That(y.Equals(x), Is.True);
        }
    }
}
