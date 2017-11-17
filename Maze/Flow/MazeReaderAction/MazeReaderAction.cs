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
				_streamReader = new StreamReader(item.FilePath); //Initializes a stream reader with the file path of the maze.

				if (!validateMaze.Contains("S")) // Checks if there is an maze entrance
				{
					Logger.Error("Could not find a maze entrance please try again");
					OnFinishOperation(item);
					throw new Exception();
				}

				if (!validateMaze.Contains("G")) // Checks if there is a maze exit
				{
					Logger.Error("Could not find a maze entrance please try again");
					OnFinishOperation(item);
					throw new Exception();
				}
			}
			catch (FileNotFoundException nfe)
			{
				Logger.Error(nfe.GetBaseException().Message);
				throw;
			}
		}

		protected override void OnFinishOperation(Operation item)
		{
			// Closes the stream and releases the unmanaged recourses that were used by the text reader
			if (_streamReader != null)
			{
				_streamReader.Dispose();
				_streamReader = null;
			}
		}

		protected override bool OnPerformOperation(Operation item)
		{
			string mapRow;
			if (_streamReader == null) return false;
			while ((mapRow = _streamReader.ReadLine()) != null) // Reads a line using the stream reader
			{

				if (item.Maze.Columns == 0)
					item.Maze.Columns = mapRow.Length; //Gets the row length
				else
				{
					if (item.Maze.Columns != mapRow.Length)
						throw new Exception("All lines must have the same length");
				}
				item.Maze.Lines.Add(mapRow); // Adds each maze row to a list of strings (will be used later in the flow)
				item.Maze.Rows++; 
			}

			return true;
		}
	}
}
