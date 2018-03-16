namespace Bots.Common.ExternelModels.Responses.BotCommands
{
	public class BaseCommandBotResponse<TReposne> : BaseBotResponse<TReposne>
		where TReposne: ICommandResponseBody
	{
		public BaseCommandBotResponse(){}

		public BaseCommandBotResponse(CommandBotResponseType respType, TReposne response, string token)
			: base(response, token)
		{
			this.respType = respType;
		}
		public CommandBotResponseType respType { get; set; }
	}
}