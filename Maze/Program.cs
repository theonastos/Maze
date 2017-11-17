using System;

namespace Maze
{
	class Program
	{
		static void Main(string[] args)
		{
			var startup = new StartUp();
			// If an exception is thrown the startup will restart
			try
			{
				startup.Start();
			}
			catch 
			{
				startup.Stop();
				Console.Write("Press Any Key to Restart");
				Console.ReadKey(true);
				startup.Start();
			}
			
			startup.Dispose(); // makes sure to release any unmanaged resources
		}
	}
}
