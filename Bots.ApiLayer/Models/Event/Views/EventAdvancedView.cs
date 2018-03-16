namespace Bots.ApiLayer.Models.Event.Views
{
	public class EventAdvancedView: EventView
	{
		public EventStatsView stats { get; set; }
        public string cleanMessage { get; set; }
	}
}