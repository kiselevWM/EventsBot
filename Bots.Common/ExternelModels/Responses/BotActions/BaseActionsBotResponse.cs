namespace Bots.Common.ExternelModels.Responses.BotActions
{
	public class BaseActionsBotResponse<TReposne> : BaseBotResponse<TReposne>
		where TReposne: IBotActionsResponseBody
	{
		public BaseActionsBotResponse(){}
		public BaseActionsBotResponse(TReposne response, string token)
			: base(response, token)
		{
		}
	}
}