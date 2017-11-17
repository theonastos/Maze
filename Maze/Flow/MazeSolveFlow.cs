using System;
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

		private readonly IMazeSolverAction _mazeSolver;
		private readonly IMazeReaderAction _mazeReader;
		private readonly IMazeLoadContentsAction _mazeLoader;

		// This class is responsible to coordinate the Operation Actions of the application

		public MazeSolveFlow(
			Operation operation,
			IMazeSolverAction mazeSolver,
			IMazeReaderAction mazeReader,
			IMazeLoadContentsAction mazeLoader)
		{
			_operation = operation ?? throw new ArgumentNullException(nameof(operation));
			_mazeReader = mazeReader ?? throw new ArgumentNullException(nameof(mazeReader));
			_mazeLoader = mazeLoader ?? throw new ArgumentNullException(nameof(mazeLoader));
			_mazeSolver = mazeSolver ?? throw new ArgumentNullException(nameof(mazeSolver));
		}


		protected override void OnStart(object context = null)
		{
			if(!_mazeReader.TryExecute(_operation, out _operation)) return;
			if(!_mazeLoader.TryExecute(_operation, out _operation)) return;
			_mazeSolver.TryExecute(_operation, out _operation);
		}

		protected override void OnStop()
		{ }
	}
}
