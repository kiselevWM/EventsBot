using Bots.ApiLayer.Models.User.Views;

namespace Bots.ApiLayer.Models.Event.Views.Task
{
	public class TaskParticipantView: UserPublicDataView
	{
		public TaskParticipantStatus taskStatus { get; set; }
	}
}