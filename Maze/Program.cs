namespace Maze
{
	class Program
	{
		static void Main(string[] args)
		{
			using (var startUp = new StartUp())
			{
				startUp.Start();
			}
		}
	}
}
