namespace Bots.Common.ExternelModels.Requests.BotUrlValidation
{
	public class BaseUrlValidationBotRequest<TRequest> : BaseBotRequest<TRequest> 
	{
		public BaseUrlValidationBotRequest() { }
		public BaseUrlValidationBotRequest(TRequest request, string lng, string token)
			: base(request, token, lng, BotRequestType.Validation)
		{

		}
	}
}