using Maze.Algorithms.SolvingAlgorithmBase;
using Maze.Models;
using Unity.Interception.Utilities;

namespace Maze.Algorithms.SolvingAlgorithmFactory
{
	public interface ISolvingAlgorithmFactory
	{
		ISolvingAlgorithm Create();
	}
}
