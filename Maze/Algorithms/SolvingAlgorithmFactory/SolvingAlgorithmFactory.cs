using System;
using Maze.Algorithms.SolvingAlgorithmBase;
using Maze.Bootstrapping.Logger;
using Maze.Models;

namespace Maze.Algorithms.SolvingAlgorithmFactory
{
	public class SolvingAlgorithmFactory : ISolvingAlgorithmFactory
	{
		private readonly ILogger _logger;
		
		public SolvingAlgorithmFactory(ILogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public ISolvingAlgorithm Create(Algorithm algorithm)
		{			
			if (algorithm == Algorithm.Recursive) return new RecursiveAlgorithm(_logger);

			return null;
		}
	}
}
