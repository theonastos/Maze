using System;
using System.IO;
using Maze.Core;
using Maze.Models;

namespace Maze.Flow.MazeLoader
{
	public class MazeLoader : PerformOperationActionBase<Operation>, IMazeLoader
	{
		protected override void OnStartOperation(Operation item)
		{
			string validateMaze = String.Empty;
			try
			{
				validateMaze = File.ReadAllText(item.FilePath);
			}
			catch (FileNotFoundException nfe)
			{
				//TODO Add logging when file not found
			}
			catch (Exception e)
			{
				if (!validateMaze.Contains("S"))
				{
					//TODO add logging when entance is not given

				}

				if (!validateMaze.Contains("G"))
				{
					//TODO add logging when exit is not given

				}
			}
		}

		protected override void OnPerformOperation(Operation item)
		{
			var mazeMap = new int[item.Maze.Rows, item.Maze.Columns];

			for (var x = 0; x < item.Maze.Rows; x++)
			{
				var mazeLine = item.Maze.Lines[x];
			}
		}
	}
}
