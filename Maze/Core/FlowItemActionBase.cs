namespace Maze.Core
{
	public abstract class FlowItemActionBase<TIn, TOut> : Runnable
	{
		public abstract bool TryExecute(TIn tin, out TOut tout);
		protected override void OnStart(object context = null){ }
		protected override void OnStop(){ }
	}
}
