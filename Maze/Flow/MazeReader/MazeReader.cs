using System;
using System.IO;
using Maze.Core;
using Maze.Models;

namespace Maze.Flow.MazeReader
{
	public class MazeReader : PerformOperationActionBase<Operation>, IMazeReader
	{
		private StreamReader _streamReader;
		
		protected override void OnStartOperation(Operation item)
		{
			_streamReader = new StreamReader(item.FilePath);
		}

		protected override void OnFinishOperation(Operation item)
		{
			if (_streamReader != null)
			{
				_streamReader.Dispose();
				_streamReader = null;
			}
		}

		protected override void OnPerformOperation(Operation item)
		{
			string mapRow;
			while ((mapRow = _streamReader.ReadLine()) != null)
			{

				if (item.Maze.Columns == 0)
					item.Maze.Columns = mapRow.Length;
				else
				{
					if (item.Maze.Columns != mapRow.Length)
						throw new Exception("The maze file appears to be corrupt. One of the lines has more/less elements than the previous one.");
				}
				item.Maze.Lines.Add(mapRow);
				item.Maze.Rows++;
			}
		}
		
	}
}
