namespace Maze.Models
{
	public enum Content
	{
		Path,
		Wall,
		Entrance,
		Exit
	}
	public class Node
	{
		public int X { get; set; }
		public int Y { get; set; }
		public Content Content { get; set; }
	}
}
