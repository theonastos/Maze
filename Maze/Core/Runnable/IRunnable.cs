using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze.Core.Runnable
{
	public interface IRunnable : IDisposable
	{
		void Start(object context = null);
		void Stop();
	}
}
