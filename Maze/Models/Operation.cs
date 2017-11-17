using System.Collections.Generic;

namespace Maze.Models
{
	public enum Algorithm
	{
		Recursive,
		Trémaux
	}
	public class Operation
	{
		public string FilePath { get; set; }
		public Algorithm Algorithm { get; set; }
		public MazeModel Maze { get; set; }
		public Stack<Node> PathToSolution { get; set; }
	}
}
