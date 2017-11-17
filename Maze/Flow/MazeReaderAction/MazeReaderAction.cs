using System;
using System.IO;
using log4net;
using Maze.Core;
using Maze.Models;

namespace Maze.Flow.MazeReaderAction
{
	public class MazeReaderAction : PerformOperationActionBase<Operation>, IMazeReaderAction
	{
		private StreamReader _streamReader;

		public MazeReaderAction(ILog logger) 
			: base(logger)
		{ }

		protected override void OnStartOperation(Operation item)
		{
			var validateMaze = String.Empty;
			try
			{
				validateMaze = File.ReadAllText(item.FilePath);
				_streamReader = new StreamReader(item.FilePath);

				if (!validateMaze.Contains("S"))
				{
					Logger.Error("Could not find a maze entrance please try again");
					OnFinishOperation(item);
				}

				if (!validateMaze.Contains("G"))
				{
					Logger.Error("Could not find a maze entrance please try again");
					OnFinishOperation(item);
				}
			}
			catch (FileNotFoundException nfe)
			{
				Logger.Error(nfe.GetBaseException().Message);
				OnFinishOperation(item);
			}
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
