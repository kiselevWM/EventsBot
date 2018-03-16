namespace Bots.Common.ExternelModels.Requests.BotCommands
{
	public class BaseCommandBotRequest<TRequestBody> : BaseBotRequest<TRequestBody>
	{
		public BaseCommandBotRequest() { }

		public BaseCommandBotRequest(string userWmid, string commandName, TRequestBody context, string lng, string token, BotCommandContext ctx)
			: base(context, token, lng, BotRequestType.BotCommand)
		{
			this.commandName = commandName;
			this.userWmid = userWmid;
			this.ctx = ctx;
		}
		public string userWmid { get; set; }
		public string commandName { get; set; }

		public BotCommandContext ctx { get; set; }
	}
}