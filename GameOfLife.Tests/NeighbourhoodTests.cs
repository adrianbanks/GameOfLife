using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace adrianbanks.GameOfLife.Tests
{
    [TestFixture]
    public sealed class NeighbourhoodTests
    {
        [Test]
        public void DeadCell_NextToThreeLiveCells_BecomesAlive()
        {
            var deadCell = new Coordinate(1, 1);
            var liveCells = new HashSet<Coordinate> { new(0, 0), new(1, 2), new(2, 0) };
            var neighbourhood = new Neighbourhood(liveCells, deadCell);

            var nextGeneration = neighbourhood.NextGenerationCells();

            var centerCellIsAlive = nextGeneration.Contains(deadCell);
            Assert.That(centerCellIsAlive, Is.True);
        }

        [Test]
        public void LiveCell_NextToTwoLiveCells_Survives()
        {
            var liveCell = new Coordinate(1, 1);
            var liveCells = new HashSet<Coordinate> { liveCell, new(0, 0), new(2, 0) };
            var neighbourhood = new Neighbourhood(liveCells, liveCell);

            var nextGeneration = neighbourhood.NextGenerationCells();

            var centerCellIsAlive = nextGeneration.Contains(liveCell);
            Assert.That(centerCellIsAlive, Is.True);
        }

        [Test]
        public void LiveCell_NextToThreeLiveCells_Survives()
        {
            var liveCell = new Coordinate(1, 1);
            var liveCells = new HashSet<Coordinate> { liveCell, new(0, 0), new(1, 2), new(2, 0) };
            var neighbourhood = new Neighbourhood(liveCells, liveCell);

            var nextGeneration = neighbourhood.NextGenerationCells();

            var centerCellIsAlive = nextGeneration.Contains(liveCell);
            Assert.That(centerCellIsAlive, Is.True);
        }

        [Test]
        public void LiveCell_NextToOneLiveCell_Dies()
        {
            var liveCell = new Coordinate(1, 1);
            var liveCells = new HashSet<Coordinate> { liveCell, new(1, 2) };
            var neighbourhood = new Neighbourhood(liveCells, liveCell);

            var nextGeneration = neighbourhood.NextGenerationCells();

            var centerCellIsAlive = nextGeneration.Contains(liveCell);
            Assert.That(centerCellIsAlive, Is.False);
        }

        [Test]
        public void LiveCell_NextToFourLiveCells_Dies()
        {
            var liveCell = new Coordinate(1, 1);
            var liveCells = new HashSet<Coordinate> { liveCell, new(0, 0), new(2, 0), new(0, 2), new(2, 2) };
            var neighbourhood = new Neighbourhood(liveCells, liveCell);

            var nextGeneration = neighbourhood.NextGenerationCells();

            var centerCellIsAlive = nextGeneration.Contains(liveCell);
            Assert.That(centerCellIsAlive, Is.False);
        }
    }
}
