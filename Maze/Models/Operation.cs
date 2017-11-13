namespace Maze.Models
{
	public enum Algorithm
	{
		Recursive,
		Trémaux,
	}
	public class Operation
	{
		public Algorithm Algorithm { get; set; }
		public MazeModel Maze { get; set; }
	}
}
