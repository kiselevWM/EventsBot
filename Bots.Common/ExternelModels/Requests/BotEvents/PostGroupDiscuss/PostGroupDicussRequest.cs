using System;
using Bots.ApiLayer.Models.User.Views;

namespace Bots.Common.ExternelModels.Requests.BotEvents.PostGroupDiscuss
{
	public class PostGroupDicussRequest
	{
		public long id { get; set; }
		public long? parentId { get; set; }
		public long eventId { get; set; }
		public string groupUid { get; set; }
		public string message { get; set; }
		public DateTime dateCreated { get; set; }
		public DateTime dateLastUpdated { get; set; }
		public UserIdentsView author { get; set; }
	}
}