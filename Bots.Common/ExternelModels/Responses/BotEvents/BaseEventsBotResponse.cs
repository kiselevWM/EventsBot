namespace Bots.Common.ExternelModels.Responses.BotEvents
{
	public class BaseEventsBotResponse<TResponseBody>: BaseBotResponse<TResponseBody>, IBaseEventsBotResponse
		where TResponseBody: IBotEventsResponseBody
	{
		public BaseEventsBotResponse(){}

		public BaseEventsBotResponse(TResponseBody response, string token)
			: base(response, token)
		{}
	}

	public interface IBaseEventsBotResponse
	{
	}
}