using System;
using Maze.Models;

namespace Maze.Core.SolverCoordinator
{
	public abstract class SolverCoordinatorBase: Runnable, ISolverCoordinator
	{
		protected SolverCoordinatorBase(Operation operation)
		{
			if (operation == null) throw new ArgumentNullException("operation");
			Operation = operation;
		}


		public Operation Operation { get; set; }
		protected abstract override void OnStop();
		protected abstract override void OnStart(object context = null);

		public void ExecuteAsync(Operation tin)
		{
			OnExecuteAsync(tin);
		}

		protected abstract void OnExecuteAsync(Operation tin);

	}
}
