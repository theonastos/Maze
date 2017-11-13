using Maze.Bootstrapping.Logger;
using Maze.Core.Runnable;
using Maze.Models;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace Maze
{
	public class StartUp : Runnable
	{
		
		protected override void OnStart(object context = null)
		{
			//var instance = new MazeModel()
			//{
			//	Width = 5,
			//	Height = 4,
			//	Entrance = new Node()
			//	{
			//		X = 1,
			//		Y = 1,
			//		Content = Content.Entrance
			//	},
			//	Exit = new Node()
			//	{
			//		X = 4,
			//		Y = 5,
			//		Content = Content.Exit
			//	}
			//};
		}

		protected override void OnStop()
		{
			
		}


		
	}
}
