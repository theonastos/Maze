using System;
using Maze.Core;
using Maze.Flow;
using Maze.Flow.MazeLoader;
using Maze.Flow.MazeReader;
using Unity;

namespace Maze
{
	public class StartUp : Runnable
	{
		public static IUnityContainer _container;

		public StartUp()
		{
			_container = new UnityContainer();
		}


		protected override void OnStart(object context = null)
		{
			//_container.RegisterType<IRunnable, Runnable>();
			_container.RegisterType<IMazeReader, MazeReader>();
			_container.RegisterType<IMazeLoader, MazeLoader>();
		}

		protected override void OnStop()
		{ }

		public void SolveMaze()
		{
			var mazeReader = _container.Resolve<IMazeReader>();
			var mazeLoader = _container.Resolve<IMazeLoader>();

			mazeReader
		}

	}
}
