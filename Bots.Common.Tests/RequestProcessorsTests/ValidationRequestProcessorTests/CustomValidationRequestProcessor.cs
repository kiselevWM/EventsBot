using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Bots.Common.ExternelModels.Responses.BotUrlValidation;
using Bots.Common.RequestProcessors.Validation;

namespace Bots.Common.Tests.RequestProcessorsTests.ValidationRequestProcessorTests
{
	internal class CustomValidationRequestProcessor : ValidationRequestProcessor
	{
		public Task<BaseUrlValidationBotResponse<UrlValidationBotResponse>> CustomProcessAsync(
			BaseUrlValidationBotRequest<UrlValidationBotRequest> request)
		{
			return base.CustomProcessAsync(request);
		}
	}
}