using System;
using Maze.Bootstrapping.Logger;
using Maze.Models;

namespace Maze.Core
{
	public abstract class PerformOperationActionBase<TFlowItem> : FlowItemActionBase<TFlowItem, Operation> 
		where TFlowItem : Operation
	{
		protected readonly ILogger _logger;

		protected PerformOperationActionBase(ILogger logger)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public override bool TryExecute(TFlowItem tin, out Operation tout)
		{
			Process(tin);

			tout = tin;
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
