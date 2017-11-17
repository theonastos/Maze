using log4net;
using Maze.Core;
using Maze.Models;

namespace Maze.Flow.MazeLoadContentAction
{
	public class MazeLoadContentsAction : PerformOperationActionBase<Operation>, IMazeLoadContentsAction
	{
		public MazeLoadContentsAction(ILog logger) 
			: base(logger)
		{ }

		protected override void OnPerformOperation(Operation item)
		{
			item.Maze.Map = new Node[item.Maze.Rows, item.Maze.Columns];

			for (var x = 0; x < item.Maze.Rows; x++)
			{
				var cellArrayOfRow = item.Maze.Lines[x].ToCharArray();
				for (var y = 0; y < cellArrayOfRow.Length; y++)
				{
					var content = cellArrayOfRow[y];

					item.Maze.Map[x, y] = new Node()
					{
						X = x,
						Y = y
					};

					switch (content.ToString())
					{
						case MazeConstants.MAZE_PATH:
							item.Maze.Map[x, y].Content = Content.Path;
							break;
						case MazeConstants.MAZE_WALL:
							item.Maze.Map[x, y].Content = Content.Wall;
							break;
						case MazeConstants.MAZE_ENTRANCE:
							item.Maze.Map[x, y].Content = Content.Entrance;
							item.Maze.Entrance = item.Maze.Map[x, y];
							break;
						case MazeConstants.MAZE_EXIT:
							item.Maze.Map[x, y].Content = Content.Exit;
							item.Maze.Exit = item.Maze.Map[x, y];
							break;
					}
				}
			}
		}
	}
}
