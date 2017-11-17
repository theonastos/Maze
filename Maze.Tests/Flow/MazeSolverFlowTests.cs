using System;
using Maze.Flow;
using Maze.Flow.MazeLoadContentAction;
using Maze.Flow.MazeReaderAction;
using Maze.Flow.MazeSolverAction;
using Maze.Models;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Flow
{
	[TestFixture]
	public class MazeSolverFlowTests
	{
		private MazeSolveFlow _flow;
		private Operation _operation;
		private Mock<IMazeSolverAction> _mazeSolverMock;
		private Mock<IMazeReaderAction> _mazeReaderMock;
		private Mock<IMazeLoadContentsAction> _mazeLoaderMock;


		[SetUp]
		public void SetUp()
		{
			
			_mazeSolverMock = new Mock<IMazeSolverAction>();
			_mazeReaderMock = new Mock<IMazeReaderAction>();
			_mazeLoaderMock = new Mock<IMazeLoadContentsAction>();

			_operation = new Operation()
			{
				FilePath = String.Concat(AppDomain.CurrentDomain.BaseDirectory, "/testMap.txt"),
				Maze = new MazeModel()
			};

			_flow = new MazeSolveFlow(
				_operation, 
				_mazeSolverMock.Object, 
				_mazeReaderMock.Object,
				_mazeLoaderMock.Object);
		}

		[Test]
		public void Given_Null_Operation_When_Constructing_MazeSolveFlow_Then_It_Throws()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() => new MazeSolveFlow(
					null,
					_mazeSolverMock.Object,
					_mazeReaderMock.Object,
					_mazeLoaderMock.Object)
				);

			Assert.That(ex.ParamName, Is.EqualTo("operation"));
		}

		[Test]
		public void Given_Null_MazeSolver_When_Constructing_MazeSolveFlow_Then_It_Throws()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() => new MazeSolveFlow(
					_operation,
					null,
					_mazeReaderMock.Object,
					_mazeLoaderMock.Object)
			);

			Assert.That(ex.ParamName, Is.EqualTo("mazeSolver"));
		}

		[Test]
		public void Given_Null_MazeReader_When_Constructing_MazeSolveFlow_Then_It_Throws()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() => new MazeSolveFlow(
					_operation,
					_mazeSolverMock.Object,
					null,
					_mazeLoaderMock.Object)
			);

			Assert.That(ex.ParamName, Is.EqualTo("mazeReader"));
		}

		[Test]
		public void Given_Null_MazeLoader_When_Constructing_MazeSolveFlow_Then_It_Throws()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() => new MazeSolveFlow(
					_operation,
					_mazeSolverMock.Object,
					_mazeReaderMock.Object,
					null)
			);

			Assert.That(ex.ParamName, Is.EqualTo("mazeLoader"));
		}


		[Test]
		public void Given_Valid_Arguments_When_OnStart_Is_Called_Then_MazeReader_Executes_Exactly_Once()
		{
			_flow.Start();

			_mazeReaderMock.Verify(x => x.TryExecute(_operation, out _operation), Times.Once);
		}

		[Test]
		public void Given_Valid_Arguments_When_OnStart_Is_Called_Then_MazeLoader_Executes_Exactly_Once()
		{
			_flow.Start();

			_mazeReaderMock.Verify(x => x.TryExecute(_operation, out _operation), Times.Once);
		}

		[Test]
		public void Given_Valid_Arguments_When_OnStart_Is_Called_Then_MazeSolver_Executes_Exactly_Once()
		{
			_flow.Start();

			_mazeReaderMock.Verify(x => x.TryExecute(_operation, out _operation), Times.Once);
		}
	}
}
