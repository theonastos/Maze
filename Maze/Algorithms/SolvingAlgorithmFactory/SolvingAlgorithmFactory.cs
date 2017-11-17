using System;
using log4net;
using Maze.Algorithms.SolvingAlgorithmBase;
using Maze.Models;

namespace Maze.Algorithms.SolvingAlgorithmFactory
{
	/// <summary>
	///     This class will create an algorithm class that implements the ISolvingAlgorithm interface depending on the algorithm that is chosen by the user
	/// </summary>

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
