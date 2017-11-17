using System;
using log4net;
using Maze.Algorithms.SolvingAlgorithmBase;
using Maze.Core.Logger;
using Maze.Models;

namespace Maze.Algorithms.SolvingAlgorithmFactory
{
	public class SolvingAlgorithmFactory : ISolvingAlgorithmFactory
	{
		private readonly Operation _operation;

		private readonly ILog _logger;
		
		public SolvingAlgorithmFactory(
			Operation operation,
			ILog logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_operation = operation ?? throw new ArgumentNullException(nameof(operation));
		}

		public ISolvingAlgorithm Create()
		{			
			if (_operation.Algorithm == Algorithm.Recursive) return new RecursiveAlgorithm(_operation, _logger);

			return null;
		}
	}
}
