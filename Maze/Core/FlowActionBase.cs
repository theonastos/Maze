using Maze.Models;

namespace Maze.Core
{
	public abstract class FlowActionBase<TIn, TOut> : IFlowAction<TIn, TOut>
		
	{
		public abstract bool TryExecute(TIn item, out TOut tout);
	}
}
