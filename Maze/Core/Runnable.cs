using System;

namespace Maze.Core
{
	public abstract class Runnable: IRunnable
	{
		public void Start(object context = null)
		{
			OnStart();
		}

		public void Stop()
		{
			OnStop();
		}
		protected abstract void OnStart(object context = null);
		protected abstract void OnStop();

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this); //Prevents a redundant garbage collection from being called
		}

		protected virtual void Dispose(bool disposing)
		{
			Stop();
		}
		
	}
}
