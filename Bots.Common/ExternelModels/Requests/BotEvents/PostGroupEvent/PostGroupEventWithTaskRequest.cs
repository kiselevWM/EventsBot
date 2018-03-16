using Bots.ApiLayer.Models.Event.Views.Task;

namespace Bots.Common.ExternelModels.Requests.BotEvents.PostGroupEvent
{
	public class PostGroupEventWithTaskRequest: PostGroupEventRequest
	{
		public TaskView task { get; set; }
	}
}