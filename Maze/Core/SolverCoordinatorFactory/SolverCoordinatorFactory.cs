using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Maze.Core.SolverCoordinator;
using Maze.Models;

namespace Maze.Core
{
	public class SolverCoordinatorFactory : ISolverCoordinatorFactory
	{
		public SolverCoordinatorFactory()
		{ }

		public ISolverCoordinator Create(Operation operation)
		{
			return new FileExportCoordinator.FileExportCoordinator(operation, _clockService, _logger, _blobServiceClient, _segmentationServiceClient);
		}
	}
}
