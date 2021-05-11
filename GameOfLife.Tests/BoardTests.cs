using System.Collections.Generic;
using adrianbanks.GameOfLife.Rendering;
using NUnit.Framework;

namespace adrianbanks.GameOfLife.Tests
{
    [TestFixture]
    public sealed class BoardTests
    {
        [Test]
        public void BoardIsCreated_WithCorrectSize()
        {
            var size = new Dimension(3, 3);
            var board = new Board(size);

            var spy = new RenderingSpy();
            board.Render(spy);

            Assert.That(spy.BoardSize, Is.EqualTo(size));
        }

        [Test]
        public void BoardIsCreated_WithCorrectLiveCells()
        {
            var liveCells = new Coordinate[] { new(1, 1) };
            var board = new Board(new Dimension(3, 3), liveCells);

            var spy = new RenderingSpy();
            board.Render(spy);

            Assert.That(spy.LiveCells, Is.EquivalentTo(liveCells));
        }

        [Test]
        public void WithNewSize_MakesBoardWithCorrectSize()
        {
            var board = new Board(new Dimension(3, 3));

            var newSize = new Dimension(6, 6);
            var newBoard = board.WithNewSize(newSize.Width, newSize.Height);

            var spy = new RenderingSpy();
            newBoard.Render(spy);

            Assert.That(spy.BoardSize, Is.EqualTo(newSize));
        }

        [Test]
        public void WithNewSize_UsesSameLiveCells()
        {
            var liveCells = new Coordinate[] { new(1, 1) };
            var board = new Board(new Dimension(3, 3), liveCells);

            var newSize = new Dimension(6, 6);
            var newBoard = board.WithNewSize(newSize.Width, newSize.Height);

            var spy = new RenderingSpy();
            newBoard.Render(spy);

            Assert.That(spy.LiveCells, Is.EquivalentTo(liveCells));
        }

        [Test]
        public void WithNewSize_RemovesLiveCellsThatFallOutside()
        {
            var liveCells = new Coordinate[] { new(1, 1), new(2, 1), new(2, 2) };
            var board = new Board(new Dimension(3, 3), liveCells);

            var newSize = new Dimension(2, 2);
            var newBoard = board.WithNewSize(newSize.Width, newSize.Height);

            var spy = new RenderingSpy();
            newBoard.Render(spy);

            var expectedLiveCells = new Coordinate[] { new(1, 1) };
            Assert.That(spy.LiveCells, Is.EquivalentTo(expectedLiveCells));
        }

        private sealed class RenderingSpy : IBoardRenderer
        {
            public Dimension BoardSize { get; private set; }
            public IEnumerable<Coordinate> LiveCells { get; private set; }

            public void Render(Dimension dimension, IEnumerable<Coordinate> liveCells)
            {
                BoardSize = dimension;
                LiveCells = liveCells;
            }
        }
    }
}
