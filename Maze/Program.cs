using Maze.Flow;

namespace Maze
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var startup = new StartUp())
			{
				startup.Start();
				startup.SolveMaze();
			}
		}
	}
}
