using System;

namespace Maze
{
	class Program
	{
		static void Main(string[] args)
		{
			var startup = new StartUp();
			try
			{
				startup.Start();
			}
			catch (Exception e)
			{

				Console.WriteLine(e);
				startup.Stop();
				Console.Write("Press Any Key to Restart");
				Console.ReadKey(true);
				startup.Start();
			}
			
			startup.Dispose();
		}
	}
}
