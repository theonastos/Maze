using System.Linq;
using log4net;

namespace Maze.Core.Logger
{
	public static class LogManagerExtensions
	{
		public static bool AtLeastOneErrorHasBeenLogged()
		{
			var flagAppenders = LogManager.GetRepository()
				.GetAppenders()
				.OfType<ErrorFlagAppender>();

			return flagAppenders.Any(f => f.ErrorOccurred);
		}
	}
}
