using Maze.Models;

namespace Maze.Core.SolverCoordinator
{
	public interface ISolverCoordinator : IRunnable
	{
		void ExecuteAsync(Operation tin);
	}
}
