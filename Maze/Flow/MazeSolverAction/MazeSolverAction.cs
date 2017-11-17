using System;
using log4net;
using Maze.Algorithms.SolvingAlgorithmBase;
using Maze.Algorithms.SolvingAlgorithmFactory;
using Maze.Core;
using Maze.Models;

namespace Maze.Flow.MazeSolverAction
{
	public class MazeSolverAction : PerformOperationActionBase<Operation>, IMazeSolverAction
	{
		private ISolvingAlgorithmFactory _solvingAlgorithmFactory;
		private ISolvingAlgorithm _solvingAlgorithm;

		public MazeSolverAction(
			ILog logger)
			: base(logger)
		{ }

		protected override void OnStartOperation(Operation item)
		{
			_solvingAlgorithmFactory = new SolvingAlgorithmFactory(item, Logger);
			_solvingAlgorithm = _solvingAlgorithmFactory.Create();
		}

		protected override void OnPerformOperation(Operation item)
		{
			_solvingAlgorithm.OnExecute();
		}

		protected override void OnFinishOperation(Operation item)
		{
			Console.WriteLine("Path To Solution Is");
			foreach (var node in item.PathToSolution)
			{
				Console.Write($"[{node.X}, {node.Y}] ");
			}
			Console.ReadKey();
		}
	}
}
