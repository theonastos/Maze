namespace Maze.Models
{
	public class MazeModel
	{
		public int Width { get; set; }
		public int Height { get; set; }
		public Node Entrance { get; set; }
		public Node Exit { get; set; }
	}
}
