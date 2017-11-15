using System;
using Maze.Bootstrapping.Logger;
using Maze.Core;
using Maze.Models;

namespace Maze.Algorithms.SolvingAlgorithmBase
{

	public abstract class SolvingAlgorithmBase : Runnable, ISolvingAlgorithm
	{
		protected SolvingAlgorithmBase(
			Operation operation,
			ILogger logger)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
			Operation = operation;
		}

		public ILogger Logger;
		public Operation Operation;

		public bool Execute()
		{
			return OnExecute();
		}

		public abstract bool OnExecute();
	}
}
