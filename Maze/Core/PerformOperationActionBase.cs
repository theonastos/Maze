using System;
using log4net;
using Maze.Models;

namespace Maze.Core
{
	public abstract class PerformOperationActionBase<TFlowItem> : FlowItemActionBase<TFlowItem, Operation> 
		where TFlowItem : Operation
	{
		protected readonly ILog Logger;

		private bool _operationSucceeded = true;

		protected PerformOperationActionBase(ILog logger)
		{
			Logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public override bool TryExecute(TFlowItem tin, out Operation tout)
		{
			Process(tin);

			tout = tin;
			return _operationSucceeded;
		}
		private void Process(TFlowItem flowItem)
		{
			OnStartOperation(flowItem);

			_operationSucceeded = OnPerformOperation(flowItem);

			OnFinishOperation(flowItem);
		}

		protected virtual void OnStartOperation(TFlowItem item) { }
		protected virtual void OnFinishOperation(TFlowItem item) { }
		protected abstract bool OnPerformOperation(TFlowItem item);
	}
}
