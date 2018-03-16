namespace Bots.Common.ExternelModels.Requests.BotCommands.EventCommand
{
	public class EventCommandBotRequest: CommandCommonBotRequest
	{
		public EventCommandBotRequest(){}

		public EventCommandBotRequest(string groupUid, string message) : base(message)
		{
			this.groupUid = groupUid;
		}
		public string groupUid { get; set; }
	}
}