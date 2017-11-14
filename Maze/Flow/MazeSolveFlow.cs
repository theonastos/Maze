using System;
using Maze.Flow.MazeLoader;
using Maze.Flow.MazeReader;
using Maze.Models;

namespace Maze.Flow
{
	public class MazeSolveFlow
	{
		public Operation _operation;

		public IMazeReader _mazeReader;
		public IMazeLoader _mazeLoader;
		public MazeSolveFlow(
			IMazeReader mazeReader,
			IMazeLoader mazeLoader)
		{
			_mazeReader = mazeReader ?? throw new ArgumentNullException(nameof(mazeReader));
			_mazeLoader = mazeLoader ?? throw new ArgumentNullException(nameof(mazeLoader));

			_operation = new Operation()
			{
				Algorithm = Algorithm.Recursive,
				FilePath = @"C:\Users\theo\Desktop\Mazes\sample.txt",
				Maze = new MazeModel()
			};
		}

		public void Solve()
		{
			//var mazeReader = new MazeReader();
			//mazeReader.TryExecute(_operation, out _operation);

			var mazeLoader = new MazeLoader.MazeLoader();
			mazeLoader.TryExecute(_operation, out _operation);

			var whatever = "string";
		}
	}
}
