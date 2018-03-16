namespace Bots.Common.ExternelModels.Responses.BotUrlValidation
{
	public class BaseUrlValidationBotResponse<TReposne> : BaseBotResponse<TReposne>
	{
		public BaseUrlValidationBotResponse() { }
		public BaseUrlValidationBotResponse(TReposne response, string token) : base(response, token){}
	}
}