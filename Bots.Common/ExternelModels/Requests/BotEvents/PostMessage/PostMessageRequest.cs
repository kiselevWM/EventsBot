using System;
using Bots.ApiLayer.Models.User.Views;

namespace Bots.Common.ExternelModels.Requests.BotEvents.PostMessage
{
	public class PostMessageRequest
	{
		public UserIdentsView author { get; set; }
		public long Id { get; set; }
		public DateTime dateCreated { get; set; }
		public string message { get; set; }
	}
}