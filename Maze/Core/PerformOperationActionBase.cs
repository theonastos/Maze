using System.Threading;
using Maze.Models;

namespace Maze.Core
{
	public abstract class PerformOperationActionBase<TFlowItem> : FlowActionBase<TFlowItem, Operation>
		where TFlowItem : Operation
	{
		public override bool TryExecute(TFlowItem item, out Operation tout)
		{
			// Fetch and export
			Process(item);

			tout = item;
			return true;
		}

		private void Process(TFlowItem flowItem)
		{
			OnStartOperation(flowItem);

			OnPerformOperation(flowItem);

			OnFinishOperation(flowItem);
		}

		protected virtual void OnStartOperation(TFlowItem item) { }
		protected virtual void OnFinishOperation(TFlowItem item) { }
		protected abstract void OnPerformOperation(TFlowItem item);
	}
}
