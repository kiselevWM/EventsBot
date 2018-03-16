using System;
using System.Threading.Tasks;
using Bots.Common.ExternelModels.Requests.BotUrlValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Bots.Common.Tests.RequestProcessorsTests.ValidationRequestProcessorTests
{
	[TestClass]
	public class ValidationRequestProcessorTests
	{
		private const string Challenge = "challenge";
		private const string Token = "token";
		private readonly CustomValidationRequestProcessor _validationRequestProcessor;

		public ValidationRequestProcessorTests()
		{
			_validationRequestProcessor = new CustomValidationRequestProcessor();
		}
		[TestMethod]
		public async Task VRPSuccess()
		{
			var resp = await _validationRequestProcessor.CustomProcessAsync(
				new BaseUrlValidationBotRequest<UrlValidationBotRequest>(new UrlValidationBotRequest(Challenge), null, Token));

			Assert.IsNotNull(resp);
			Assert.AreEqual(Token, resp.token);
			Assert.IsNotNull(resp.response);
			Assert.AreEqual(resp.response.challenge, Challenge);
		}

		[TestMethod]
		public async Task VRPWrongIncomeParameterFail()
		{
			try
			{
				await _validationRequestProcessor.CustomProcessAsync(
					new BaseUrlValidationBotRequest<UrlValidationBotRequest>(new UrlValidationBotRequest(null), null, Token));
				Assert.Fail("No exception on bad request.");
			}
			catch (ArgumentException e){}
			
		}
	}
}