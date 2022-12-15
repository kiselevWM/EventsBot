using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bots.ApiLayer.Api.Message;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Requests.BotCommands;
using Bots.Common.ExternelModels.Requests.BotCommands.MessageCommand;
using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Bots.Common.ExternelModels.Responses.BotCommands;
using Bots.Common.ExternelModels.Responses.BotUrlValidation;
using Bots.Common.Models;
using Bots.Common.RequestProcessors.Base;
using Bots.Common.RequestProcessors.Base.Localization;
using Bots.Common.RequestProcessors.Commands;
using Bots.Common.RequestProcessors.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Bots.Common.Tests.RequestProcessorsTests.BaseRequestProcessorTests
{
	[TestClass]
	public class BaseRPChoosingProcessorTest
	{
		private readonly BaseRequestProcessor _proc;
		private bool _commandProcessorIsChoosen;
		private bool _validationProcessorIsChoosen;

		public BaseRPChoosingProcessorTest()
		{
			var localizationServiceMock = new Mock<ILocalizationService>();
			localizationServiceMock.Setup(x => x.SetLocale(It.IsAny<string>()));
			var authServiceMock = new Mock<IBotAuthService>();
			authServiceMock.Setup(x => x.IsAuthBotRequest(It.IsAny<string>())).Returns(true);
			_commandProcessorIsChoosen = false;
			var commandProcessorMock = new Mock<ICustomRequestProcessor<BaseCommandBotRequest<JToken>, BaseCommandBotResponse<ICommandResponseBody>, ICommandResponseBody>>();
			commandProcessorMock.Setup(x => x.ProcessAsync(It.IsAny<BaseCommandBotRequest<JToken>>()))
				.Returns(() => Task.FromResult<BaseCommandBotResponse<ICommandResponseBody>>(null))
				.Callback(() => _commandProcessorIsChoosen = true);
			commandProcessorMock.Setup(x => x.RequestType).Returns(BotRequestType.BotCommand);

			_validationProcessorIsChoosen = false;
			var validationProcessorMock = new Mock<ICustomRequestProcessor<BaseUrlValidationBotRequest<JToken>,
				BaseUrlValidationBotResponse<UrlValidationBotResponse>, UrlValidationBotResponse>>();
			validationProcessorMock.Setup(x => x.ProcessAsync(It.IsAny<BaseUrlValidationBotRequest<JToken>>()))
				.Returns(() => Task.FromResult<BaseUrlValidationBotResponse<UrlValidationBotResponse>>(null))
				.Callback(() => _validationProcessorIsChoosen = true);
			validationProcessorMock.Setup(x => x.RequestType).Returns(BotRequestType.Validation);
			_proc = new TestRequestProcessor(authServiceMock.Object, validationProcessorMock.Object, 
				localizationServiceMock.Object).SetRequestProcessor(commandProcessorMock.Object);
		}

		[TestMethod]
		public async Task BaseRPChoosingProcessorOk()
		{
			var commandRequest = JsonConvert.SerializeObject(
				new BaseCommandBotRequest<MessageCommandBotRequest>("123", "asdasd", new MessageCommandBotRequest("mes", null),
					"ru", null, BotCommandContext.MessagingPostForm));

			await _proc.ProcessAsync(commandRequest);
			Assert.IsTrue(_commandProcessorIsChoosen);
			Assert.IsFalse(_validationProcessorIsChoosen);
			_commandProcessorIsChoosen = false;

			var validationReqObj = new BaseUrlValidationBotRequest<UrlValidationBotRequest>(new UrlValidationBotRequest(), null, null);

			var validationRequest = JsonConvert.SerializeObject(validationReqObj);

			await _proc.ProcessAsync(validationRequest);
			Assert.IsFalse(_commandProcessorIsChoosen);
			Assert.IsTrue(_validationProcessorIsChoosen);
			_validationProcessorIsChoosen = false;
		}

		public async Task BaseRPChoosingProcessorBadRequestTypeFail()
		{
			var validationReqObj = new BaseUrlValidationBotRequest<UrlValidationBotRequest>(new UrlValidationBotRequest(), null, null);
			validationReqObj.requestType = (BotRequestType)99999999;
			try
			{
				await _proc.ProcessAsync(JsonConvert.SerializeObject(validationReqObj));
				Assert.Fail("There is not base request type exception.");
			}
			catch (NotSupportedException e) { }

			Assert.IsFalse(_commandProcessorIsChoosen);
			Assert.IsFalse(_validationProcessorIsChoosen);
		}
	}
}