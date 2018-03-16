using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Responses;
using Newtonsoft.Json.Linq;

namespace Bots.Common.RequestProcessors.Base
{
	public interface ICustomRequestProcessor<in TBaseRequest, TBaseResponse, TResponse>
		where TBaseRequest: BaseBotRequest<JToken>
		where TBaseResponse : BaseBotResponse<TResponse>
	{
		Task<TBaseResponse> ProcessAsync(TBaseRequest request);
		BotRequestType RequestType { get; }
	}
}