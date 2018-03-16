using Bots.ApiLayer.Models.Event.Views.Task;

namespace Bots.Common.ExternelModels.Requests.BotEvents.PostGroupDiscuss
{
	public class PostGroupDicussWithTaskRequest: PostGroupDicussRequest
	{
		public TaskView task { get; set; }
	}
}