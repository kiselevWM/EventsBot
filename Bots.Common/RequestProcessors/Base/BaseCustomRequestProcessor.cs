using System;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bots.Common.RequestProcessors.Base
{
	/// <summary>
	/// If an income request executes more than timeoute, processor will return empty results 
	/// and when user processing is finished we'll process it using callback func
	/// </summary>
	public abstract class BaseCustomRequestProcessor<TBaseJsonRequest, TBaseResponse, TBaseResponseBody>
		: ICustomRequestProcessor<TBaseJsonRequest, TBaseResponse, TBaseResponseBody>
		where TBaseJsonRequest: BaseBotRequest<JToken>
		where TBaseResponse : BaseBotResponse<TBaseResponseBody>
	{
		protected abstract bool TryGetProcessor(TBaseJsonRequest request, out Func<TBaseJsonRequest, Task<TBaseResponse>> func);
		public abstract BotRequestType RequestType { get; }
		public async Task<TBaseResponse> ProcessAsync(TBaseJsonRequest request)
		{
			if (request == null) throw new ArgumentNullException(nameof(request));
			if (request.request == null) throw new ArgumentNullException(nameof(request.request));

			if (TryGetProcessor(request, out var func))
				return await func(request);

			return null;
		}
		protected virtual async Task<TBaseGenericResponse> ProcessWrapper<TBaseRequest, TRequestBody, TBaseGenericResponse, TResponseBody>(
			TBaseJsonRequest request, Func<TBaseJsonRequest, TRequestBody, TBaseRequest> createRequestFunc, 
			Func<TBaseRequest, Task<TBaseGenericResponse>> processFunc) 
			where TBaseRequest : BaseBotRequest<TRequestBody>
			where TResponseBody : TBaseResponseBody
			where TBaseGenericResponse: BaseBotResponse<TResponseBody>
		{
			var customRequest = CreateRequest(request, createRequestFunc);
			return await Process<TBaseRequest, TRequestBody, TBaseGenericResponse, TResponseBody>(processFunc, customRequest);
		}

		protected virtual async Task<TBaseGenericResponse> Process<TBaseRequest, TRequestBody, TBaseGenericResponse, TResponseBody>
			(Func<TBaseRequest, Task<TBaseGenericResponse>> processFunc, TBaseRequest customRequest) 
			where TBaseRequest : BaseBotRequest<TRequestBody>
			where TResponseBody : TBaseResponseBody
			where TBaseGenericResponse: BaseBotResponse<TResponseBody>
		{
			return await processFunc(customRequest).ConfigureAwait(false);
		}

		protected virtual TBaseRequest CreateRequest<TBaseRequest, TRequestBody>(TBaseJsonRequest request, 
			Func<TBaseJsonRequest, TRequestBody, TBaseRequest> createRequestFunc) 
			where TBaseRequest : BaseBotRequest<TRequestBody>
		{
			var requestBody = JsonConvert.DeserializeObject<TRequestBody>(request.request.ToString());
			return createRequestFunc(request, requestBody);
		}
	}
}