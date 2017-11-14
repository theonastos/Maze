using System;

namespace Maze.Core
{
	public interface IRunnable : IDisposable
	{
		void Start(object context = null);
		void Stop();
	}
}
