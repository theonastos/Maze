using System;
using log4net;
using Maze.Flow.MazeReaderAction;
using Maze.Models;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Flow
{

	public class MazeReaderActionTests
	{
		private Mock<ILog> _logger;
		private Operation _operation;
		private MazeReaderAction _mazeReader;

		[SetUp]
		public void SetUp()
		{
			_logger = new Mock<ILog>();
			_mazeReader = new MazeReaderAction(_logger.Object);

			_operation = new Operation()
			{
				FilePath = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "/testMap.txt"),
				Maze = new MazeModel()
			};
		}

		[Test]
		public void Given_Valid_Arguments_When_Constructing_MazeReaderAction_Then_An_Instance_Is_Created()
		{
			Assert.IsInstanceOf<IMazeReaderAction>(_mazeReader);
		}

		[Test]
		public void Given_Valid_Arguments_When_TryExecute_Is_Called_Then_Rows_Are_Correct()
		{
			_mazeReader.TryExecute(_operation, out _operation);

			Assert.That(_operation.Maze.Rows, Is.EqualTo(6));
			Assert.That(_operation.Maze.Columns, Is.EqualTo(8));
		}

		[Test]
		public void Given_Valid_Arguments_When_TryExecute_Is_Called_Then_Collumns_Are_Correct()
		{
			_mazeReader.TryExecute(_operation, out _operation);

			Assert.That(_operation.Maze.Rows, Is.EqualTo(6));
			Assert.That(_operation.Maze.Columns, Is.EqualTo(8));
		}

		[Test]
		public void Given_Valid_Arguments_When_TryExecute_Is_Called_Then_Lines_Are_Correct()
		{
			_mazeReader.TryExecute(_operation, out _operation);

			Assert.That(_operation.Maze.Lines.Count, Is.EqualTo(_operation.Maze.Rows));
			Assert.That(_operation.Maze.Lines[0], Is.EqualTo("_____GX_"));
			Assert.That(_operation.Maze.Lines[5], Is.EqualTo("S_______"));
		}

		[TearDown]
		public void TearDown()
		{
			
		}
	}
}
