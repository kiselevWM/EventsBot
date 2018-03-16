namespace Bots.Common.ExternelModels.Requests.BotUrlValidation
{
	public class UrlValidationBotRequest
	{
		public UrlValidationBotRequest(){}

		public UrlValidationBotRequest(string challenge)
		{
			this.challenge = challenge;
		}
		public string challenge { get; set; }
	}
}