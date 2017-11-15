using Maze.Models;

namespace Maze.Core
{
	public interface IFlowAction<TIn, TOut>
	{
		bool TryExecute(TIn item, out TOut tout);
	}
}
