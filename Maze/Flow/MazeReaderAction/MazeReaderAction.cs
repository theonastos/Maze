using System;
using System.IO;
using Maze.Bootstrapping.Logger;
using Maze.Core;
using Maze.Models;

namespace Maze.Flow.MazeReaderAction
{
	public class MazeReaderAction : PerformOperationActionBase<Operation>, IMazeReaderAction
	{
		private StreamReader _streamReader;

		public MazeReaderAction(ILogger logger) 
			: base(logger)
		{ }

		protected override void OnStartOperation(Operation item)
		{
			var validateMaze = String.Empty;
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
						throw new Exception("All lines must have the same length");
				}
				item.Maze.Lines.Add(mapRow);
				item.Maze.Rows++;
			}
		}
	}
}
