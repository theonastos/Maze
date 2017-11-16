using System;
using System.Text.RegularExpressions;
using Maze.Bootstrapping.Logger;
using Maze.Core;
using Maze.Flow;
using Maze.Flow.MazeLoadContentAction;
using Maze.Flow.MazeReaderAction;
using Maze.Flow.MazeSolverAction;
using Maze.Models;
using Unity;

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
				Maze = new MazeModel()
			};
		}

		private void RenderAlgorithmMenu()
		{
			Console.WriteLine("Trémaux [1]");
			Console.WriteLine("Recursive [0]");
			ConsoleKeyInfo userInput;
			do
			{
				userInput = Console.ReadKey(true);

				switch (userInput.KeyChar.ToString())
				{
					case "0":
						_operation.Algorithm = Algorithm.Recursive;
						return;
					case "1":
						_operation.Algorithm = Algorithm.Trémaux;
						return;
				}
			} while (userInput.Key != ConsoleKey.Escape);
		}

		protected override void OnStart(object context = null)
		{
			_container.RegisterType<ILogger, Logger>();
			_container.RegisterType<IMazeReaderAction, MazeReaderAction>();
			_container.RegisterType<IMazeLoadContentsAction, MazeLoadContentsAction>();
			_container.RegisterType<IMazeSolverAction, MazeSolverAction>();

			var algorithmMenu = new Menu()
			{
				Subtitle = "Choose the algorithm you want to use to solve the maze.",
				Action = RenderAlgorithmMenu
			};

			var getMazePathMenu = new Menu()
			{
				Subtitle = "Type absolut path of the maze map file.",
				Action = () =>
				{
					do
					{
						_operation.FilePath = Console.ReadLine();
						if (Regex.IsMatch(_operation.FilePath, MazeConstants.PATH_REGEX))
						{
							break;
						}
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("It is not a valid path, Please Try again");
						Console.ResetColor();
					} while (true);
				}
			};

			algorithmMenu.Run();
			getMazePathMenu.Run();

			StartFlow();
		}

		private void StartFlow()
		{
			var logger = _container.Resolve<ILogger>();
			var mazeLoader = _container.Resolve<IMazeLoadContentsAction>();
			var mazeReader = _container.Resolve<IMazeReaderAction>();
			var mazeSolver = _container.Resolve<IMazeSolverAction>();

			var flow = new MazeSolveFlow(_operation, logger, mazeSolver, mazeReader, mazeLoader);
			flow.Start();
			flow.Stop();
		}

		protected override void OnStop()
		{ }

	}
}
