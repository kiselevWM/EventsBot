namespace Bots.Common.ExternelModels.Responses.BotUrlValidation
{
	public class UrlValidationBotResponse
	{
		public UrlValidationBotResponse(){}

		public UrlValidationBotResponse(string challenge)
		{
			this.challenge = challenge;
		}
		public string challenge { get; set; }
	}
}