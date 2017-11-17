using System;
using System.Linq;
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
			_solvingAlgorithmFactory = new SolvingAlgorithmFactory(item, Logger); // This factory with create an instance of the user selected algorithm class
			_solvingAlgorithm = _solvingAlgorithmFactory.Create(); 
		}

		protected override bool OnPerformOperation(Operation item)
		{
			_solvingAlgorithm.OnExecute(); // Executes the solving algorithm

			return true;
		}

		protected override void OnFinishOperation(Operation item) // Print the maze solution to the user (will throw exception if no solution)
		{
			if (item.PathToSolution.Count == 0)
			{
				Console.WriteLine("No solution was found");
				throw new Exception();
			}

			Console.WriteLine("\nPath To Solution Is\n");
			foreach (var node in item.PathToSolution)
			{
				Console.Write($"[{node.X}, {node.Y}] ");
			}
			Console.ReadKey();
		}
	}
}
