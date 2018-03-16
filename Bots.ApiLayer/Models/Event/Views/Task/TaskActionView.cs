using System.Collections.Generic;
using Bots.ApiLayer.Models.User.Views;

namespace Bots.ApiLayer.Models.Event.Views.Task
{
	public class TaskActionView
	{
		public TaskActionType type { get; set; }
		public IList<UserPublicDataView> participants { get; set; }
        public string desc { get; set; }
	}
}