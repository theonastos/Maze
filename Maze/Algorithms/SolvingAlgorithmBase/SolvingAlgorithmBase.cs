using System;
using Maze.Bootstrapping.Logger;
using Maze.Core;
using Maze.Models;

namespace Maze.Algorithms.SolvingAlgorithmBase
{

	public abstract class SolvingAlgorithmBase : Runnable, ISolvingAlgorithm
	{
		protected SolvingAlgorithmBase(ILogger logger)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
			
		}

		public ILogger Logger;
		public Operation Operation;

		public bool Execute(Operation tin)
		{
			return OnExecute(tin);
		}

		public abstract bool OnExecute(Operation tin);
	}
}
