using System;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests.BotCommands.DiscussCommand;
using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Bots.Common.ExternelModels.Responses.BotUrlValidation;
using Bots.Common.RequestProcessors.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Bots.Common.Tests.RequestProcessorsTests.ValidationRequestProcessorTests
{
	[TestClass]
	public class BaseValidationRequestProcessorTests
	{
		private const string Challenge = "challed";
		private const string Token = "token";
		private readonly ValidationPtocessorTest _proc;
		public BaseValidationRequestProcessorTests()
		{
			_proc = new ValidationPtocessorTest();
		}

		private class ValidationPtocessorTest : BaseValidationRequestProcessor
		{
			protected override Task<BaseUrlValidationBotResponse<UrlValidationBotResponse>> CustomProcessAsync(
				BaseUrlValidationBotRequest<UrlValidationBotRequest> request)
			{
				return Task.FromResult(new BaseUrlValidationBotResponse<UrlValidationBotResponse>(new UrlValidationBotResponse(Challenge), request.token));
			}
		}
		[TestMethod]
		public async Task BVRPDesOk()
		{
			var resp = await _proc.ProcessAsync(
				new BaseUrlValidationBotRequest<JToken>(JToken.FromObject(new UrlValidationBotRequest(Challenge)), null, Token));
			Assert.AreEqual(Challenge, resp.response.challenge);
			Assert.AreEqual(Token, resp.token);
		}

		[TestMethod]
		public async Task BVRPDesFromStrFail()
		{
			try
			{
				await _proc.ProcessAsync(
					new BaseUrlValidationBotRequest<JToken>(JToken.FromObject("asdasd asdas as aaa"), null, Token));
				Assert.Fail("No exception on bad request.");
			}
			catch (ArgumentException e) { }
		}

		[TestMethod]
		public async Task BVRPDesFromWrongObjFail()
		{
			try
			{
				await _proc.ProcessAsync(
					new BaseUrlValidationBotRequest<JToken>(JToken.FromObject(new DiscussCommandBotRequest()), null, Token));
				Assert.Fail("No exception on bad request.");
			}
			catch (ArgumentException e) { }
		}
	}
}