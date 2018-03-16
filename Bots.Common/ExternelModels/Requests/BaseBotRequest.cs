using Newtonsoft.Json.Linq;

namespace Bots.Common.ExternelModels.Requests
{
	public class BaseBotRequest<TRequest>
	{
		protected BaseBotRequest() { }
		protected BaseBotRequest(TRequest request, string token, string lng, BotRequestType requestType)
		{
			this.lng = lng;
			this.request = request;
			this.token = token;
			this.requestType = requestType;
		}

		protected BaseBotRequest(BaseBotRequest<JToken> request, TRequest requestBody)
			:this(requestBody, request.token, request.lng, request.requestType){}
		
		public BotRequestType requestType { get; set; }
		public TRequest request { get; set; }
		public string lng { get; set; }
		public string token { get; set; }
	}
}