using Bots.Common.Models.Events;
using Newtonsoft.Json.Linq;

namespace Bots.Common.ExternelModels.Requests.BotEvents
{
	public class BaseEventsBotRequest<TRequestBody> : BaseBotRequest<TRequestBody>
	{
		public BaseEventsBotRequest(){}

		public BaseEventsBotRequest(BotEvent botEvent, TRequestBody context, string lng, string token) 
			: base(context, token, lng, BotRequestType.BotEvent)
		{
			this.botEvent = botEvent;
		}

		public BaseEventsBotRequest(BaseEventsBotRequest<JToken> request, TRequestBody requestBody)
			:this(request.botEvent, requestBody, request.lng, request.token){}

		public BotEvent botEvent { get; set; }
		public BaseEventsBotRequest<TNewRequest> Create<TNewRequest>(BaseEventsBotRequest<JToken> req, TNewRequest requestBody)
		{
			return new BaseEventsBotRequest<TNewRequest>(req, requestBody);
		}
	}
}