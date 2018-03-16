using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Bots.Common.ExternelModels.Responses.BotUrlValidation;
using Bots.Common.RequestProcessors.Base;
using Bots.Common.RequestProcessors.Base.Localization;
using Bots.Common.RequestProcessors.Commands;
using Bots.Common.RequestProcessors.Validation;
using Newtonsoft.Json.Linq;

namespace Bots.Common.Tests.RequestProcessorsTests.BaseRequestProcessorTests
{
	internal class TestRequestProcessor: BaseRequestProcessor
	{
		public TestRequestProcessor(IBotAuthService authService, ICustomRequestProcessor<BaseUrlValidationBotRequest<JToken>,
				BaseUrlValidationBotResponse<UrlValidationBotResponse>, UrlValidationBotResponse> validationRequestProcessor,
			ILocalizationService localizationService)
			: base(authService, validationRequestProcessor, localizationService)
		{

		}
	}
}