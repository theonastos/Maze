using System;
using Maze.Algorithms.SolvingAlgorithmBase;
using Maze.Algorithms.SolvingAlgorithmFactory;
using Maze.Bootstrapping.Logger;
using Maze.Core;
using Maze.Models;

namespace Maze.Flow.MazeSolverAction
{
	public class MazeSolverAction : PerformOperationActionBase<Operation>, IMazeSolverAction
	{
		private ISolvingAlgorithmFactory _solvingAlgorithmFactory;
		private ISolvingAlgorithm _solvingAlgorithm;

		public MazeSolverAction(
			ILogger logger)
			: base(logger)
		{ }

		protected override void OnStartOperation(Operation item)
		{
			_solvingAlgorithmFactory = new SolvingAlgorithmFactory(_logger);
			_solvingAlgorithm = _solvingAlgorithmFactory.Create(item.Algorithm);
		}

		protected override void OnPerformOperation(Operation item)
		{
			_solvingAlgorithm.OnExecute(item);
		}
	}
}
