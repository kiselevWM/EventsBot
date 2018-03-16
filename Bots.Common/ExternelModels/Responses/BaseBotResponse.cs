namespace Bots.Common.ExternelModels.Responses
{
	public abstract class BaseBotResponse<TReposne>
	{
		protected BaseBotResponse(){}

		protected BaseBotResponse(TReposne response, string token)
		{
			this.response = response;
			//this.lng = lng;
			this.token = token;
		}
		public TReposne response { get; set; }
		//public string lng { get; set; }
		public string token { get; set; }
	}
}