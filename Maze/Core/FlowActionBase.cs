using Maze.Bootstrapping.Logger;

namespace Maze.Core
{
	public class FlowActionBase : Runnable
	{

		public ILogger Logger;
		protected override void OnStart(object context = null)
		{}

		protected override void OnStop()
		{}
	}
}
