namespace Maze.Core
{
	public interface IFlowItemActionBase<TIn, TOut>
	{
		bool TryExecute(TIn tin, out TOut tout);
	}
}
