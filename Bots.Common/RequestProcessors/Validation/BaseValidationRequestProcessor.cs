using System;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Bots.Common.ExternelModels.Responses.BotUrlValidation;
using Bots.Common.RequestProcessors.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bots.Common.RequestProcessors.Validation
{
	public abstract class BaseValidationRequestProcessor: ICustomRequestProcessor<BaseUrlValidationBotRequest<JToken>,
		BaseUrlValidationBotResponse<UrlValidationBotResponse>, UrlValidationBotResponse>
	{
		public Task<BaseUrlValidationBotResponse<UrlValidationBotResponse>> ProcessAsync(BaseUrlValidationBotRequest<JToken> request)
		{
			if (request?.request == null) throw new ArgumentException($"Request body is empty. RequestBody: {request}.", nameof(request));
			UrlValidationBotRequest validationRequest;
			try
			{
				validationRequest = JsonConvert.DeserializeObject<UrlValidationBotRequest>(request.request.ToString());
				if(validationRequest?.challenge == null) throw new ArgumentException($"Request challenge is empty. RequestBody: {request}.", nameof(request));
			}
			catch (Exception e)
			{
				throw new ArgumentException($"Request body is empty. RequestBody: {request}.", nameof(request));
			}
			return CustomProcessAsync(new BaseUrlValidationBotRequest<UrlValidationBotRequest>(validationRequest, request.lng, request.token));
		}

		public BotRequestType RequestType => BotRequestType.Validation;

		protected abstract Task<BaseUrlValidationBotResponse<UrlValidationBotResponse>> CustomProcessAsync(
																		BaseUrlValidationBotRequest<UrlValidationBotRequest> request);
	}
}