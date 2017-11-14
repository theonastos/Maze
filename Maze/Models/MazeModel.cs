using System.Collections.Generic;

namespace Maze.Models
{
	public class MazeModel
	{
		public MazeModel()
		{
			Lines = new List<string>();
		}

		public List<string> Lines { get; set; }

		public int Columns { get; set; }

		public int Rows { get; set; }

		public Node Entrance { get; set; }
		public Node Exit { get; set; }
	}
}
