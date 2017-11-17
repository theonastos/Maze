using System;
using log4net;
using Maze.Models;

namespace Maze.Algorithms.SolvingAlgorithmBase
{

	public abstract class SolvingAlgorithmBase : ISolvingAlgorithm
	{
		protected SolvingAlgorithmBase(
			Operation operation,
			ILog logger)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
			Operation = operation ?? throw new ArgumentNullException(nameof(operation));
		}

		public ILog Logger;
		public Operation Operation;

		public bool Execute()
		{
			return OnExecute();
		}

		public abstract bool OnExecute();
	}
}
