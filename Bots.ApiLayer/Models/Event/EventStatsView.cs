namespace Bots.ApiLayer.Models.Event
{
	public class EventStatsView
	{
		 /// <summary>
        /// Количество комментариев
        /// </summary>
        public int discusscount { get; set; }
        /// <summary>
        /// Количество новых комментариев
        /// </summary>
        public int discussunreadedcount { get; set; }
        /// <summary>
        /// Количество просмотров
        /// </summary>
        public int viewscount { get; set; }
	}
}