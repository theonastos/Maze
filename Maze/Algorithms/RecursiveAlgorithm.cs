using System;
using Maze.Algorithms.SolvingAlgorithmFactory;
using Maze.Bootstrapping.Logger;
using Maze.Models;

namespace Maze.Algorithms
{
	public class RecursiveAlgorithm : SolvingAlgorithmBase.SolvingAlgorithmBase
	{
		public RecursiveAlgorithm(
			Operation operation, 
			ILogger logger) 
			: base(operation, logger)
		{
			
		}

		protected override void OnStart(object context = null)
		{
			
		}

		protected override void OnStop()
		{
			
		}

		public override bool OnExecute()
		{
			throw new System.NotImplementedException();
		}
	}
}
