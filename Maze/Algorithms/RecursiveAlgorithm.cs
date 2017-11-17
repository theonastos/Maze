using System.Collections.Generic;
using log4net;
using Maze.Models;

namespace Maze.Algorithms
{
	public class RecursiveAlgorithm : SolvingAlgorithmBase.SolvingAlgorithmBase
	{
		private readonly bool[,] _visited;
		private readonly bool[,] _correctPath;

		public RecursiveAlgorithm(
			Operation operation,
			ILog logger)
			: base(operation, logger)
		{
			_visited = new bool[operation.Maze.Columns, operation.Maze.Rows];
			_correctPath = new bool[operation.Maze.Columns, operation.Maze.Rows];
		}

		public bool RecursiveSolve(int x, int y)
		{
			if (x == Operation.Maze.Exit.X && y == Operation.Maze.Exit.Y) return true;
			if (Operation.Maze.Map[x, y].Content == Content.Wall || _visited[x, y]) return false;
			// If you are on a wall or already were here
			_visited[x, y] = true;
			if (x != 0) // Checks if not on left edge
				if (RecursiveSolve(x - 1, y))
				{ // Recalls method one to the left
					_correctPath[x, y] = true; // Sets that path value to true;
					Operation.PathToSolution.Push(Operation.Maze.Map[x, y]);
					return true;
				}
			if (x != Operation.Maze.Rows - 1) // Checks if not on right edge
				if (RecursiveSolve(x + 1, y))
				{ // Recalls method one to the right
					_correctPath[x, y] = true;
					Operation.PathToSolution.Push(Operation.Maze.Map[x, y]);
					return true;
				}
			if (y != 0)  // Checks if not on top edge
				if (RecursiveSolve(x, y - 1))
				{ // Recalls method one up
					_correctPath[x, y] = true;
					Operation.PathToSolution.Push(Operation.Maze.Map[x, y]);
					return true;
				}
			if (y != Operation.Maze.Columns - 1) // Checks if not on bottom edge
				if (RecursiveSolve(x, y + 1))
				{ // Recalls method one down
					_correctPath[x, y] = true;
					Operation.PathToSolution.Push(Operation.Maze.Map[x, y]);
					return true;
				}
			return false;
		}

		public override bool OnExecute()
		{
			Operation.PathToSolution = new Stack<Node>();
			RecursiveSolve(Operation.Maze.Entrance.X, Operation.Maze.Entrance.Y);
			Operation.PathToSolution.Push(Operation.Maze.Exit);
			return true;
		}
	}
}
