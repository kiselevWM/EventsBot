using System;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Bots.Common.ExternelModels.Responses.BotUrlValidation;

namespace Bots.Common.RequestProcessors.Validation
{
	public class ValidationRequestProcessor: BaseValidationRequestProcessor
	{
		protected override Task<BaseUrlValidationBotResponse<UrlValidationBotResponse>> CustomProcessAsync(
							BaseUrlValidationBotRequest<UrlValidationBotRequest> request)
		{
			if (request?.request?.challenge == null) throw new ArgumentException($"Bad request body.", nameof(request));

			var response = new BaseUrlValidationBotResponse<UrlValidationBotResponse>(
													new UrlValidationBotResponse(request.request.challenge), request.token);
			return Task.FromResult(response);
		}
	}
}