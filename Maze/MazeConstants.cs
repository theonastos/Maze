using System.Text.RegularExpressions;

namespace Maze
{
	public class MazeConstants
	{
		public const string MAZE_PATH = "_";
		public const string MAZE_EXIT = "G";
		public const string MAZE_WALL = "X";
		public const string MAZE_ENTRANCE = "S";
		public const string PATH_REGEX = @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$";
	}
}
