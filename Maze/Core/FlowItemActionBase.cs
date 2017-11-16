namespace Maze.Core
{
	public abstract class FlowItemActionBase<TIn, TOut>
	{
		public abstract bool TryExecute(TIn tin, out TOut tout);
		
	}
}
