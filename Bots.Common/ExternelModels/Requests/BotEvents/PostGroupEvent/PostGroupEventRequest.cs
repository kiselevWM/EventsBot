using System;
using Bots.ApiLayer.Models.User.Views;

namespace Bots.Common.ExternelModels.Requests.BotEvents.PostGroupEvent
{
	public class PostGroupEventRequest
	{
		public long id { get; set; }
		public string groupUid { get; set; }
		public string message { get; set; }
		public DateTime dateCreated { get; set; }
		public DateTime dateLastUpdated { get; set; }
		public UserIdentsView author { get; set; }
	}
}