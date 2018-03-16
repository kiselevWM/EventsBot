namespace Bots.Common.ExternelModels.Requests.BotCommands.DiscussCommand
{
	public class DiscussCommandBotRequest : CommandCommonBotRequest
	{
		//for serializer
		public DiscussCommandBotRequest(){}
		public DiscussCommandBotRequest(long? parentId, long eventId, string groupUid, string message) : base(message)
		{
			this.parentId = parentId;
			this.eventId = eventId;
			this.groupUid = groupUid;
		}
		public long? parentId { get; set; }
		public long eventId { get; set; }
		public string groupUid { get; set; }
	}
}
