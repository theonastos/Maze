using System.Collections.Generic;
using log4net;
using Maze.Flow.MazeLoadContentAction;
using Maze.Models;
using Moq;
using NUnit.Framework;

namespace Maze.Tests.Flow
{
	[TestFixture]
	public class MazeLoadContentsActionTests
	{
		private Mock<ILog> _logger;
		private MazeLoadContentsAction _mazeLoader;
		
		[SetUp]
		public void SetUp()
		{
			_logger = new Mock<ILog>();
			_mazeLoader = new MazeLoadContentsAction(_logger.Object);
		}

		[Test]
		public void Given_Valid_Arguments_When_Constructing_MazeLoadContentsAction_Then_An_Instance_Is_Created()
		{
			Assert.IsInstanceOf<IMazeLoadContentsAction>(_mazeLoader);
		}

		[Test]
		public void Given_Valid_Arguments_When_TryExecute_Is_Called_Then_Map_Has_Correct_Values()
		{
			var operation = new Operation()
			{
				Algorithm = Algorithm.Recursive,
				Maze = new MazeModel()
				{
					Columns = 4,
					Rows = 4,
					Entrance = new Node(),
					Exit = new Node(),
					Lines = new List<string>()
					{
						"G_X_",
						"X_X_",
						"__S_",
						"__XX"
					},
					Map = new Node[4, 4]
				}
			};

			_mazeLoader.TryExecute(operation, out operation);

			Assert.That(operation.Maze.Map[0, 0].Content, Is.EqualTo(Content.Exit));
			Assert.That(operation.Maze.Map[1, 1].Content, Is.EqualTo(Content.Path));
			Assert.That(operation.Maze.Map[2, 2].Content, Is.EqualTo(Content.Entrance));
			Assert.That(operation.Maze.Map[3, 3].Content, Is.EqualTo(Content.Wall));
		}
	}
}
