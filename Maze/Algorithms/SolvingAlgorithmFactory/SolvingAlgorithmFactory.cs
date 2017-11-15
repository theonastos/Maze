using System;
using Maze.Algorithms.SolvingAlgorithmBase;
using Maze.Bootstrapping.Logger;
using Maze.Models;

namespace Maze.Algorithms.SolvingAlgorithmFactory
{
	public class SolvingAlgorithmFactory : ISolvingAlgorithmFactory
	{
		private readonly ILogger _logger;
		private readonly Operation _operation;

		public SolvingAlgorithmFactory(
			Operation operation,
			ILogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_operation = operation ?? throw new ArgumentNullException(nameof(operation));
		}

		public ISolvingAlgorithm Create(Algorithm algorithm)
		{			
			if (algorithm == Algorithm.Recursive) return new RecursiveAlgorithm(_operation, _logger);

			return null;
		}
	}
}
