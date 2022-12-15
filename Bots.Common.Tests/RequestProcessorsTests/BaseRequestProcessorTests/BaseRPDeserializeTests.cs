using System;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests;
using Bots.Common.ExternelModels.Requests.BotCommands;
using Bots.Common.ExternelModels.Requests.BotCommands.DiscussCommand;
using Bots.Common.ExternelModels.Requests.BotCommands.MessageCommand;
using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Bots.Common.ExternelModels.Responses.BotCommands;
using Bots.Common.ExternelModels.Responses.BotUrlValidation;
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
	public class BaseRPDeserializeTests
	{
		private readonly Mock<ICustomRequestProcessor<BaseUrlValidationBotRequest<JToken>,
			BaseUrlValidationBotResponse<UrlValidationBotResponse>, UrlValidationBotResponse>> _validationProcessorMock;
		private readonly Mock<IBotAuthService> _authServiceMock;
		private readonly Mock<ICustomRequestProcessor<BaseCommandBotRequest<JToken>, BaseCommandBotResponse<ICommandResponseBody>, ICommandResponseBody>> _commandProcessorMock;
		private readonly Mock<ILocalizationService> _localizationServiceMock;
		private readonly BaseRequestProcessor _proc;
		private const string Token = "token";
		public BaseRPDeserializeTests()
		{
			_localizationServiceMock = new Mock<ILocalizationService>();
			_localizationServiceMock.Setup(x => x.SetLocale(It.IsAny<string>()));
			_validationProcessorMock = new Mock<ICustomRequestProcessor<BaseUrlValidationBotRequest<JToken>,
				BaseUrlValidationBotResponse<UrlValidationBotResponse>, UrlValidationBotResponse>>();
			_validationProcessorMock.Setup(x => x.ProcessAsync(It.IsAny<BaseUrlValidationBotRequest<JToken>>())).Returns(() => null);
			_authServiceMock = new Mock<IBotAuthService>();
			_authServiceMock.Setup(s => s.IsAuthBotRequest(It.IsAny<string>())).Returns(true);
			_commandProcessorMock = new Mock<ICustomRequestProcessor<BaseCommandBotRequest<JToken>, BaseCommandBotResponse<ICommandResponseBody>, ICommandResponseBody>>();
			_commandProcessorMock.Setup(x => x.ProcessAsync(It.IsAny<BaseCommandBotRequest<JToken>>()))
				.Returns(() => Task.FromResult(new BaseCommandBotResponse<ICommandResponseBody>(
					CommandBotResponseType.Post, new BotCommandStateResponse("mes", BotCommandStateType.Success), Token)));
			_commandProcessorMock.Setup(x => x.RequestType).Returns(BotRequestType.BotCommand);
			_proc = new TestRequestProcessor(_authServiceMock.Object, _validationProcessorMock.Object, 
				_localizationServiceMock.Object).SetRequestProcessor(_commandProcessorMock.Object);
		}

		[TestMethod]
		public async Task BaseRPDesOk()
		{
			var serilaizedObject = JsonConvert.SerializeObject(
				new BaseCommandBotRequest<MessageCommandBotRequest>("123", "asdasd", new MessageCommandBotRequest("mes", null),
					"ru-RU", Token, BotCommandContext.MessagingPostForm));
			var trueResultStr = await _proc.ProcessAsync(serilaizedObject);
			Assert.IsNotNull(trueResultStr);
			BaseCommandBotResponse<BotCommandStateResponse> trueResult = null;
			try
			{
				trueResult = JsonConvert.DeserializeObject<BaseCommandBotResponse<BotCommandStateResponse>>(trueResultStr);
				Assert.IsNotNull(trueResult);
			}
			catch (Exception e)
			{
				Assert.Fail("Can not deserialize trueResult response string");
			}
			Assert.IsNotNull(trueResult.response);
			Assert.AreEqual(Token, trueResult.token);
			Assert.AreEqual(CommandBotResponseType.Post, trueResult.respType);
		}

		[TestMethod]
		public async Task BaseRPDesFromStrFail()
		{
			try
			{
				var randomWrongString = "1sabn43''asdasd/asdasd";
				await _proc.ProcessAsync(randomWrongString);
				Assert.Fail("incorrect process wrong string");
			}
			catch (ArgumentException e) { }
		}

		[TestMethod]
		public async Task BaseRPDesFromRandomObjFail()
		{
			try
			{
				var wrongSerilaizedObjectStr = JsonConvert.SerializeObject(new { a = 1, b = "sdasd" });
				await _proc.ProcessAsync(wrongSerilaizedObjectStr);
				Assert.Fail("incorrect process wrong object");
			}
			catch (ArgumentException) { }
		}

		[TestMethod]
		public async Task BaseRPDesFromIncorrectObjFailTest()
		{
			try
			{
				var discussReqSerilaizedObjectStr = JsonConvert.SerializeObject(new DiscussCommandBotRequest());
				await _proc.ProcessAsync(discussReqSerilaizedObjectStr);
				Assert.Fail("incorrect process wrong object");
			}
			catch (ArgumentException) { }
		}
	}
}