using Maze.Algorithms.SolvingAlgorithmBase;
using Maze.Algorithms.SolvingAlgorithmFactory;
using Maze.Bootstrapping.Logger;
using Maze.Core;
using Maze.Flow;
using Maze.Flow.MazeLoadContentAction;
using Maze.Flow.MazeReaderAction;
using Maze.Flow.MazeSolverAction;
using Maze.Models;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Maze
{
	public class StartUp : Runnable
	{
		private readonly Operation _operation;

		private readonly IUnityContainer _container;
		
		public StartUp()
		{
			_container = new UnityContainer();
			_operation = new Operation()
			{
				Algorithm = Algorithm.Recursive,
				FilePath = @"C:\Users\theo\Desktop\Mazes\sample.txt",
				Maze = new MazeModel()
			};
		}

		protected override void OnStart(object context = null)
		{
			_container.RegisterType<ILogger, Logger>();
			_container.RegisterType<IMazeReaderAction, MazeReaderAction>();
			_container.RegisterType<IMazeLoadContentsAction, MazeLoadContentsAction>();
			_container.RegisterType<IMazeSolverAction, MazeSolverAction>();
		}

		protected override void OnStop()
		{ }

		public void SolveMaze()
		{
			var logger = _container.Resolve<ILogger>();
			var mazeLoader = _container.Resolve<IMazeLoadContentsAction>();
			var mazeReader = _container.Resolve<IMazeReaderAction>();
			var mazeSolver = _container.Resolve<IMazeSolverAction>();

			var test = new MazeSolveFlow(_operation, logger, mazeSolver, mazeReader, mazeLoader);
			test.Solve();
		}
	}
}
