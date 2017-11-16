using System;
using Maze.Bootstrapping.Logger;
using Maze.Core;
using Maze.Flow.MazeLoadContentAction;
using Maze.Flow.MazeReaderAction;
using Maze.Flow.MazeSolverAction;
using Maze.Models;

namespace Maze.Flow
{
	public class MazeSolveFlow : Runnable
	{
		public Operation _operation;

		private ILogger _logger;
		private readonly IMazeSolverAction _mazeSolver;
		private readonly IMazeReaderAction _mazeReader;
		private readonly IMazeLoadContentsAction _mazeLoader;

		public MazeSolveFlow(
			Operation operation,
			ILogger logger,
			IMazeSolverAction mazeSolver,
			IMazeReaderAction mazeReader,
			IMazeLoadContentsAction mazeLoader)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_operation = operation ?? throw new ArgumentNullException(nameof(operation));
			_mazeReader = mazeReader ?? throw new ArgumentNullException(nameof(mazeReader));
			_mazeLoader = mazeLoader ?? throw new ArgumentNullException(nameof(mazeLoader));
			_mazeSolver = mazeSolver ?? throw new ArgumentNullException(nameof(mazeSolver));

		}

		protected override void OnStart(object context = null)
		{
			_mazeReader.TryExecute(_operation, out _operation);
			_mazeLoader.TryExecute(_operation, out _operation);
			_mazeSolver.TryExecute(_operation, out _operation);
		}

		protected override void OnStop()
		{ }
	}
}
