using System;

namespace Maze
{
	public class Menu
	{
		public string Subtitle { get; set; }
		public Action Action { get; set; }
		public void DisplayHeader()
		{
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.Blue;
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine("~ Maze Solving Case Study ~");
			Console.WriteLine();
			Console.ResetColor();

			if (Subtitle != null)
			{
				Console.WriteLine(String.Concat(Subtitle, "\n"));
			}
		}

		public void Run()
		{
			DisplayHeader();
			Action();
		}
	}
}
